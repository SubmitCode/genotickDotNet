using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using SetStats = com.alphatica.genotick.timepoint.SetStats;
	using TimePointExecutor = com.alphatica.genotick.timepoint.TimePointExecutor;
	using TimePointExecutorFactory = com.alphatica.genotick.timepoint.TimePointExecutorFactory;
	using TimePointStats = com.alphatica.genotick.timepoint.TimePointStats;
	using BreederSettings = com.alphatica.genotick.breeder.BreederSettings;
	using RobotBreeder = com.alphatica.genotick.breeder.RobotBreeder;
	using RobotBreederFactory = com.alphatica.genotick.breeder.RobotBreederFactory;
	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using RobotKiller = com.alphatica.genotick.killer.RobotKiller;
	using RobotKillerFactory = com.alphatica.genotick.killer.RobotKillerFactory;
	using RobotKillerSettings = com.alphatica.genotick.killer.RobotKillerSettings;
	using Mutator = com.alphatica.genotick.mutator.Mutator;
	using MutatorFactory = com.alphatica.genotick.mutator.MutatorFactory;
	using MutatorSettings = com.alphatica.genotick.mutator.MutatorSettings;
	using com.alphatica.genotick.population;
	using RobotExecutorFactory = com.alphatica.genotick.processor.RobotExecutorFactory;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	public class Simulation
	{
		private readonly UserOutput output;
		private Population population;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("WeakerAccess") public Simulation(com.alphatica.genotick.ui.UserOutput output)
		public Simulation(UserOutput output)
		{
			this.output = output;
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("UnusedReturnValue") public java.util.List<com.alphatica.genotick.timepoint.TimePointStats> start(MainSettings mainSettings, com.alphatica.genotick.data.MainAppData data) throws IllegalAccessException
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		public virtual IList<TimePointStats> start(MainSettings mainSettings, MainAppData data)
		{
			if (!validateSettings(mainSettings))
			{
				return null;
			}
			logSettings(mainSettings);
			RobotKiller killer = getRobotKiller(mainSettings);
			Mutator mutator = getMutator(mainSettings);
			RobotBreeder breeder = wireBreeder(mainSettings, mutator);
			population = wirePopulation(mainSettings);
			Engine engine = wireEngine(mainSettings, data, killer, breeder, population);
			IList<TimePointStats> results = engine.start(output);
			showSummary(results);
			return results;
		}

		public virtual Population Population
		{
			get
			{
				return population;
			}
		}

		private bool validateSettings(MainSettings settings)
		{
			try
			{
				settings.validate();
				return true;
			}
			catch (System.ArgumentException ex)
			{
				Console.WriteLine(ex.ToString());
				Console.Write(ex.StackTrace);
				output.errorMessage(ex.Message);
				return false;
			}
		}

		private Engine wireEngine(MainSettings mainSettings, MainAppData data, RobotKiller killer, RobotBreeder breeder, Population population)
		{
			EngineSettings engineSettings = getEngineSettings(mainSettings);
			TimePointExecutor timePointExecutor = wireTimePointExecutor(mainSettings);
			return EngineFactory.getDefaultEngine(engineSettings, data, timePointExecutor, killer, breeder, population);
		}

		private TimePointExecutor wireTimePointExecutor(MainSettings settings)
		{
			DataSetExecutor dataSetExecutor = new SimpleDataSetExecutor();
			RobotExecutorSettings robotExecutorSettings = new RobotExecutorSettings(settings);
			RobotExecutorFactory robotExecutorFactory = new RobotExecutorFactory(robotExecutorSettings);
			return TimePointExecutorFactory.getDefaultExecutor(dataSetExecutor, robotExecutorFactory,output);
		}

		private Population wirePopulation(MainSettings settings)
		{
			PopulationDAO dao = PopulationDAOFactory.getDefaultDAO(settings.populationDAO);
			Population population = PopulationFactory.getDefaultPopulation(dao);
			population.DesiredSize = settings.populationDesiredSize;
			return population;
		}

		private RobotBreeder wireBreeder(MainSettings settings, Mutator mutator)
		{
			BreederSettings breederSettings = new BreederSettings(settings.minimumOutcomesBetweenBreeding, settings.inheritedChildWeight, settings.minimumOutcomesToAllowBreeding, settings.randomRobotsAtEachUpdate, settings.dataMaximumOffset, settings.ignoreColumns);
			return RobotBreederFactory.getDefaultBreeder(breederSettings, mutator);
		}

		private RobotKiller getRobotKiller(MainSettings settings)
		{
			RobotKillerSettings killerSettings = new RobotKillerSettings();
			killerSettings.maximumDeathByAge = settings.maximumDeathByAge;
			killerSettings.maximumDeathByWeight = settings.maximumDeathByWeight;
			killerSettings.probabilityOfDeathByAge = settings.probabilityOfDeathByAge;
			killerSettings.probabilityOfDeathByWeight = settings.probabilityOfDeathByWeight;
			killerSettings.protectRobotsUntilOutcomes = settings.protectRobotsUntilOutcomes;
			killerSettings.protectBestRobots = settings.protectBestRobots;
			killerSettings.killNonPredictingRobots = settings.killNonPredictingRobots;
			killerSettings.requireSymmetricalRobots = settings.requireSymmetricalRobots;
			return RobotKillerFactory.getDefaultRobotKiller(killerSettings,output);
		}

		private Mutator getMutator(MainSettings settings)
		{
			MutatorSettings mutatorSettings = new MutatorSettings(settings.instructionMutationProbability, settings.newInstructionProbability, settings.skipInstructionProbability);
			return MutatorFactory.getDefaultMutator(mutatorSettings);
		}


		private EngineSettings getEngineSettings(MainSettings settings)
		{
			EngineSettings engineSettings = new EngineSettings();
			engineSettings.startTimePoint = settings.startTimePoint;
			engineSettings.endTimePoint = settings.endTimePoint;
			engineSettings.performTraining = settings.performTraining;
			engineSettings.resultThreshold = settings.resultThreshold;
			return engineSettings;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void logSettings(MainSettings settings) throws IllegalAccessException
		private void logSettings(MainSettings settings)
		{
			string settingsString = settings.String;
			output.infoMessage(settingsString);
		}

		private void showSummary(IList<TimePointStats> list)
		{
			IDictionary<DataSetName, double?> statsResults = new Dictionary<DataSetName, double?>();
			double result = 1;
			foreach (TimePointStats stats in list)
			{
				double percent = stats.PercentEarned;
				recordSetsProfit(stats,statsResults);
				result *= percent / 100.0 + 1;
			}
			showStatsResults(statsResults);
			output.infoMessage("Final result for genotick: " + result);
		}

		private void recordSetsProfit(TimePointStats stats, IDictionary<DataSetName, double?> statsResults)
		{
			foreach (KeyValuePair<DataSetName, SetStats> entry in stats.listSets())
			{
				recordProfit(entry.Key,entry.Value,statsResults);
			}
		}

		private void recordProfit(DataSetName name, SetStats setStats, IDictionary<DataSetName, double?> statsResults)
		{
			double? soFar = statsResults[name];
			if (soFar == null)
			{
				soFar = 0.0;
			}
			soFar += setStats.TotalPercent;
			statsResults[name] = soFar;
		}

		private void showStatsResults(IDictionary<DataSetName, double?> statsResults)
		{
			foreach (KeyValuePair<DataSetName, double?> entry in statsResults.SetOfKeyValuePairs())
			{
				output.infoMessage("Profit for " + entry.Key + ": " + entry.Value);
			}
		}
	}

}