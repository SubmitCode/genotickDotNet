using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.timepoint
{

	using com.alphatica.genotick.genotick;
	using com.alphatica.genotick.population;
	using RobotExecutorFactory = com.alphatica.genotick.processor.RobotExecutorFactory;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	internal class SimpleTimePointExecutor : TimePointExecutor
	{

		private readonly ExecutorService executorService;
		private readonly IList<RobotInfo> robotInfos;
		private readonly UserOutput output;
		private DataSetExecutor dataSetExecutor;
		private RobotExecutorFactory robotExecutorFactory;


		public SimpleTimePointExecutor(UserOutput output)
		{
			int cores = Runtime.Runtime.availableProcessors();
			executorService = Executors.newFixedThreadPool(cores * 2, new DaemonThreadFactory());
			robotInfos = Collections.synchronizedList(new List<RobotInfo>());
			this.output = output;
		}

		public virtual IList<RobotInfo> RobotInfos
		{
			get
			{
				return robotInfos;
			}
		}

		public virtual TimePointResult execute(IList<RobotData> robotDataList, Population population, bool updateRobots)
		{
			robotInfos.Clear();
			TimePointResult timePointResult = new TimePointResult();
			if (robotDataList.Count == 0)
			{
				return timePointResult;
			}
			IList<Future<IList<RobotResult>>> tasks = submitTasks(robotDataList,population,updateRobots);
			getResults(timePointResult,tasks);
			return timePointResult;
		}

		private void getResults(TimePointResult timePointResult, IList<Future<IList<RobotResult>>> tasks)
		{
			while (tasks.Count > 0)
			{
				try
				{
					int lastIndex = tasks.Count - 1;
					Future<IList<RobotResult>> future = tasks[lastIndex];
					IList<RobotResult> results = future.get();
					tasks.RemoveAt(lastIndex);
					results.ForEach(timePointResult.addRobotResult);
				}
				catch (InterruptedException)
				{
					/* Do nothing, try again */
				}
				catch (ExecutionException e)
				{
					output.errorMessage(e.Message);
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
					Environment.Exit(1);
				}
			}
		}


		public virtual void setSettings(DataSetExecutor dataSetExecutor, RobotExecutorFactory robotExecutorFactory)
		{
			this.dataSetExecutor = dataSetExecutor;
			this.robotExecutorFactory = robotExecutorFactory;
		}

		/*
		   Return type here is as ugly as it gets and I'm not proud. However, it seems to be the quickest.
		   */
		private IList<Future<IList<RobotResult>>> submitTasks(IList<RobotData> robotDataList, Population population, bool updateRobots)
		{
			IList<Future<IList<RobotResult>>> tasks = new List<Future<IList<RobotResult>>>();
			foreach (RobotName robotName in population.listRobotsNames())
			{
				Task task = new Task(this, robotName, robotDataList, population, updateRobots);
				Future<IList<RobotResult>> future = executorService.submit(task);
				tasks.Add(future);
			}
			return tasks;
		}

		private class Task : Callable<IList<RobotResult>>
		{
			private readonly SimpleTimePointExecutor outerInstance;


			internal readonly RobotName robotName;
			internal readonly IList<RobotData> robotDataList;
			internal readonly Population population;
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
			internal readonly bool updateRobots_Renamed;

			public Task(SimpleTimePointExecutor outerInstance, RobotName robotName, IList<RobotData> robotDataList, Population population, bool updateRobots)
			{
				this.outerInstance = outerInstance;
				this.robotName = robotName;
				this.robotDataList = robotDataList;
				this.population = population;
				this.updateRobots_Renamed = updateRobots;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public java.util.List<RobotResult> call() throws Exception
			public override IList<RobotResult> call()
			{
				RobotExecutor robotExecutor = outerInstance.robotExecutorFactory.DefaultRobotExecutor;
				Robot robot = population.getRobot(robotName);
				IList<RobotResult> list = outerInstance.dataSetExecutor.execute(robotDataList, robot, robotExecutor);
				if (updateRobots_Renamed)
				{
					updateRobots(robot,list);
				}
				RobotInfo robotInfo = new RobotInfo(robot);
				outerInstance.robotInfos.Add(robotInfo);
				return list;
			}

			internal virtual void updateRobots(Robot robot, IList<RobotResult> list)
			{
				IList<Outcome> outcomes = new List<Outcome>();
				foreach (RobotResult result in list)
				{
					robot.recordPrediction(result.Prediction);
					Outcome outcome = Outcome.getOutcome(result.Prediction,result.Data.ActualChange);
					outcomes.Add(outcome);
				}
				robot.recordOutcomes(outcomes);
				population.saveRobot(robot);
			}
		}
	}


}