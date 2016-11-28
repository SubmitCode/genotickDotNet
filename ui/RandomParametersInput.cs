using System;

namespace com.alphatica.genotick.ui
{

	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using Main = com.alphatica.genotick.genotick.Main;
	using MainSettings = com.alphatica.genotick.genotick.MainSettings;
	using RandomGenerator = com.alphatica.genotick.genotick.RandomGenerator;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") class RandomParametersInput extends BasicUserInput
	internal class RandomParametersInput : BasicUserInput
	{
		private Random r = RandomGenerator.assignRandom();

		public override MainSettings getSettings(UserOutput output)
		{
			MainSettings defaults = MainSettings.Settings;
			defaults.populationDAO = "";
			defaults.requireSymmetricalRobots = true;
			defaults.killNonPredictingRobots = true;
			defaults.performTraining = true;
			MainAppData data = getData(Main.DEFAULT_DATA_DIR,output);
			assignTimePoints(defaults, data);
			return assignRandom(defaults);
		}

		private void assignTimePoints(MainSettings defaults, MainAppData data)
		{
			TimePoint first = data.FirstTimePoint;
			TimePoint last = data.LastTimePoint;
			long diff = last.Value - first.Value;
			long count = Math.Abs(r.nextLong() % diff);
			defaults.startTimePoint = new TimePoint(last.Value - count);
			defaults.endTimePoint = last;
		}

		private MainSettings assignRandom(MainSettings settings)
		{

			settings.dataMaximumOffset = r.Next(256) + 1;
			settings.processorInstructionLimit = r.Next(256) + 1;
			settings.maximumDeathByAge = r.NextDouble();
			settings.maximumDeathByWeight = r.NextDouble();
			settings.probabilityOfDeathByAge = r.NextDouble();
			settings.probabilityOfDeathByWeight = r.NextDouble();
			settings.inheritedChildWeight = r.NextDouble();
			settings.protectRobotsUntilOutcomes = r.Next(100);
			settings.protectBestRobots = r.NextDouble();
			settings.newInstructionProbability = r.NextDouble();
			settings.instructionMutationProbability = r.NextDouble();
			settings.skipInstructionProbability = settings.newInstructionProbability;
			settings.minimumOutcomesToAllowBreeding = r.Next(50);
			settings.minimumOutcomesBetweenBreeding = r.Next(50);
			settings.randomRobotsAtEachUpdate = r.NextDouble();
			settings.resultThreshold = 1 + (r.NextDouble() * 9);
			return settings;

		}

	}

}