using System;
using System.Collections.Generic;
using System.Threading;

namespace com.alphatica.genotick.genotick
{

	using NoDataForTimePointException = com.alphatica.genotick.data.NoDataForTimePointException;
	using RobotInfo = com.alphatica.genotick.population.RobotInfo;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;
	using TimePointExecutor = com.alphatica.genotick.timepoint.TimePointExecutor;
	using TimePointResult = com.alphatica.genotick.timepoint.TimePointResult;
	using TimePointStats = com.alphatica.genotick.timepoint.TimePointStats;
	using RobotBreeder = com.alphatica.genotick.breeder.RobotBreeder;
	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using DataUtils = com.alphatica.genotick.data.DataUtils;
	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using RobotKiller = com.alphatica.genotick.killer.RobotKiller;
	using Population = com.alphatica.genotick.population.Population;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;



	public class SimpleEngine : Engine
	{
		private EngineSettings engineSettings;
		private TimePointExecutor timePointExecutor;
		private RobotKiller killer;
		private RobotBreeder breeder;
		private Population population;
		private MainAppData data;
		private readonly ProfitRecorder profitRecorder;

		private SimpleEngine()
		{
			profitRecorder = new ProfitRecorder();
		}
		public static Engine Engine
		{
			get
			{
				return new SimpleEngine();
			}
		}

		public virtual IList<TimePointStats> start(UserOutput output)
		{
			Thread.CurrentThread.Name = "Main engine execution thread";
			double result = 1;
			initPopulation();
			TimePoint timePoint = new TimePoint(engineSettings.startTimePoint);
			IList<TimePointStats> timePointStats = new List<TimePointStats>();
			while (engineSettings.endTimePoint.CompareTo(timePoint) >= 0)
			{
				TimePointStats stat = executeTimePoint(timePoint, output);
				if (stat != null)
				{
					timePointStats.Add(stat);
					result *= (stat.PercentEarned / 100 + 1);
					profitRecorder.recordProfit(stat.PercentEarned);
					output.reportProfitForTimePoint(timePoint,(result - 1) * 100, stat.PercentEarned);
				}
				timePoint = timePoint.next();
			}
			if (engineSettings.performTraining)
			{
				savePopulation(output);
			}
			showSummary(output);
			return timePointStats;
		}

		private void showSummary(UserOutput output)
		{
			output.infoMessage("Total: Profit: " + profitRecorder.Profit + " Drawdown: " + profitRecorder.MaxDrawdown + " Profit / DD: " + profitRecorder.Profit / profitRecorder.MaxDrawdown);
			output.infoMessage("Second Half: Profit: " + profitRecorder.ProfitSecondHalf + " Drawdown: " + profitRecorder.MaxDrawdownSecondHalf + " Profit / DD: " + profitRecorder.ProfitSecondHalf / profitRecorder.MaxDrawdownSecondHalf);
		}

		private void savePopulation(UserOutput output)
		{
			string dirName = SavedPopulationDirName;
			File dirFile = new File(dirName);
			if (!dirFile.exists() && !dirFile.mkdirs())
			{
				output.errorMessage("Unable to create directory " + dirName);
			}
			else
			{
				population.savePopulation(dirName);
			}
		}

		public virtual void setSettings(EngineSettings engineSettings, TimePointExecutor timePointExecutor, MainAppData data, RobotKiller killer, RobotBreeder breeder, Population population)
		{
			this.engineSettings = engineSettings;
			this.timePointExecutor = timePointExecutor;
			this.killer = killer;
			this.breeder = breeder;
			this.population = population;
			this.data = data;
		}

		private string SavedPopulationDirName
		{
			get
			{
				return "savedPopulation_" + Tools.PidString;
			}
		}

		private void initPopulation()
		{
			if (population.Size == 0 && engineSettings.performTraining)
			{
				breeder.breedPopulation(population, timePointExecutor.RobotInfos);
			}
		}

		private TimePointStats executeTimePoint(TimePoint timePoint, UserOutput output)
		{
			IList<RobotData> robotDataList = data.prepareRobotDataList(timePoint);
			if (robotDataList.Count == 0)
			{
				return null;
			}
			TimePointResult timePointResult = timePointExecutor.execute(robotDataList, population, engineSettings.performTraining);
			TimePointStats timePointStats = TimePointStats.getNewStats(timePoint);
			foreach (DataSetResult dataSetResult in timePointResult.listDataSetResults())
			{
				Prediction prediction = dataSetResult.getCumulativePrediction(engineSettings.resultThreshold);
				output.showPrediction(timePoint,dataSetResult.Name,prediction);
				tryUpdate(dataSetResult,timePoint,prediction,output,timePointStats);
			}
			if (engineSettings.performTraining)
			{
				updatePopulation();
			}
			return timePointStats;
		}

		private void tryUpdate(DataSetResult dataSetResult, TimePoint timePoint, Prediction prediction, UserOutput output, TimePointStats timePointStats)
		{
			try
			{
				double? actualChange = data.getActualChange(dataSetResult.Name,timePoint);
				if (!double.IsNaN(actualChange))
				{
					printPercentEarned(dataSetResult.Name, actualChange.Value, prediction, output);
					if (!double.IsInfinity(actualChange) && !double.IsNaN(actualChange) && prediction != null)
					{
						timePointStats.update(dataSetResult.Name, actualChange.Value, prediction);
					}
				}
			}
			catch (NoDataForTimePointException)
			{
				/* Empty */
			}
		}

		private void printPercentEarned(DataSetName name, double actualChange, Prediction prediction, UserOutput output)
		{
			double percent;
			if (prediction == Prediction.OUT)
			{
				return;
			}
			if (prediction.isCorrect(actualChange))
			{
				percent = Math.Abs(actualChange);
			}
			else
			{
				percent = -Math.Abs(actualChange);
			}
			output.infoMessage("Profit for " + name + " " + percent);
		}

		private void updatePopulation()
		{
			IList<RobotInfo> list = timePointExecutor.RobotInfos;
			killer.killRobots(population,list);
			breeder.breedPopulation(population,list);
		}
	}

}