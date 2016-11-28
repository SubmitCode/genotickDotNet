using System;

namespace com.alphatica.genotick.ui
{

	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using Main = com.alphatica.genotick.genotick.Main;
	using MainSettings = com.alphatica.genotick.genotick.MainSettings;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") class ConsoleInput extends BasicUserInput
	internal class ConsoleInput : BasicUserInput
	{
		private readonly Console console;

		internal ConsoleInput()
		{
			console = System.console();
			if (console == null)
			{
				throw new Exception("Unable to create system console");
			}
		}

		public override MainSettings getSettings(UserOutput output)
		{
			string dataDirectory = getString("Data directory", Main.DEFAULT_DATA_DIR);
			MainAppData data = getData(dataDirectory,output);
			MainSettings settings = MainSettings.Settings;
			settings.dataSettings = dataDirectory;
			settings.performTraining = getBoolean("Perform training", settings.performTraining);
			settings.startTimePoint = new TimePoint(getLong("Start time point",data.FirstTimePoint.Value));
			settings.endTimePoint = new TimePoint(getLong("End time point", data.LastTimePoint.Value));
			settings.populationDAO = getString("Population storage", settings.populationDAO);
			settings.processorInstructionLimit = getInteger("Processor instruction limit", settings.processorInstructionLimit);
			settings.resultThreshold = getDouble("Result threshold",settings.resultThreshold);
			if (settings.performTraining)
			{
				settings.dataMaximumOffset = getInteger("Data maximum offset", settings.dataMaximumOffset);
				settings.populationDesiredSize = getInteger("Population desired size", settings.populationDesiredSize);
				settings.maximumDeathByAge = getDouble("Maximum death rate by age", settings.maximumDeathByAge);
				settings.maximumDeathByWeight = getDouble("Maximum death rate by weight", settings.maximumDeathByWeight);
				settings.probabilityOfDeathByAge = getDouble("Probability of death by age", settings.probabilityOfDeathByAge);
				settings.probabilityOfDeathByWeight = getDouble("Probability of death by weight", settings.probabilityOfDeathByWeight);
				settings.inheritedChildWeight = getDouble("Inherited child's weight", settings.inheritedChildWeight);
				settings.protectRobotsUntilOutcomes = getInteger("Protect robots until outcomes", settings.protectRobotsUntilOutcomes);
				settings.newInstructionProbability = getDouble("Probability of new instruction", settings.newInstructionProbability);
				// This looks like an error but it's not. Default value for 'skipInstruction...' is same as 'newInstruction'
				// to keep robots more or less constant size.
				settings.skipInstructionProbability = getDouble("Probability of skipping instruction", settings.newInstructionProbability);
				settings.instructionMutationProbability = getDouble("Instruction mutation probability", settings.instructionMutationProbability);
				settings.minimumOutcomesToAllowBreeding = getLong("Minimum outcomes to allow breeding", settings.minimumOutcomesToAllowBreeding);
				settings.minimumOutcomesBetweenBreeding = getLong("Minimum outcomes between breeding", settings.minimumOutcomesBetweenBreeding);
				settings.killNonPredictingRobots = getBoolean("Kill non-predicting robots", settings.killNonPredictingRobots);
				settings.randomRobotsAtEachUpdate = getDouble("Random robots at each update", settings.randomRobotsAtEachUpdate);
				settings.protectBestRobots = getDouble("Protect best robots", settings.protectBestRobots);
				settings.requireSymmetricalRobots = getBoolean("Require symmetrical robots", settings.requireSymmetricalRobots);
				settings.ignoreColumns = getInteger("Ignore columns for training",settings.ignoreColumns);
			}
			return settings;
		}

		private double getDouble(string s, double value)
		{
			string str = value.ToString();
			displayMessage(s,str);
			string response = getString(null,str);
			return double.Parse(response);
		}

		private int getInteger(string message, int def)
		{
			string str = def.ToString();
			displayMessage(message,str);
			string response = getString(null,str);
			return int.Parse(response);
		}

		private bool getBoolean(string message, bool def)
		{
			string str = def.ToString();
			displayMessage(message, str);
			string response = getString(null,str);
			return Convert.ToBoolean(response);
		}

		private long getLong(string message, long def)
		{
			string str = def.ToString();
			displayMessage(message,str);
			string response = getString(null,str);
			return long.Parse(response);
		}

		private string getString(string message, string def)
		{
			displayMessage(message, def);
			string response = console.readLine();
			if (response.Equals(""))
			{
				return def;
			}
			else
			{
				return response;
			}
		}

		private void displayMessage(string message, string def)
		{
			if (!string.ReferenceEquals(message, null))
			{
				Console.Write(string.Format("{0} [{1}]: ",message,def));
			}
		}
	}

}