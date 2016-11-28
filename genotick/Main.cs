using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;

namespace com.alphatica.genotick.genotick
{

	using com.alphatica.genotick.data;
	using Population = com.alphatica.genotick.population.Population;
	using PopulationDAOFileSystem = com.alphatica.genotick.population.PopulationDAOFileSystem;
	using Robot = com.alphatica.genotick.population.Robot;
	using RobotInfo = com.alphatica.genotick.population.RobotInfo;
	using Reversal = com.alphatica.genotick.reversal.Reversal;
	using Parameters = com.alphatica.genotick.ui.Parameters;
	using UserInput = com.alphatica.genotick.ui.UserInput;
	using UserInputOutputFactory = com.alphatica.genotick.ui.UserInputOutputFactory;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	public class Main
	{
		public const string DEFAULT_DATA_DIR = "data";
		private const string VERSION = "Genotick version 0.11.0 (copyleft 2016)";
		private static UserInput input;
		private static UserOutput output;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static void main(String... args) throws IOException, IllegalAccessException
		public static void main(params string[] args)
		{
			Parameters parameters = new Parameters(args);
			checkVersionRequest(parameters);
			checkShowPopulation(parameters);
			checkShowRobot(parameters);
			getUserIO(parameters);
			setupExceptionHandler();
			checkReverse(parameters);
			checkYahoo(parameters);
			checkSimulation(parameters);
		}


		private static void checkShowRobot(Parameters parameters)
		{
			string value = parameters.getValue("showRobot");
			if (!string.ReferenceEquals(value, null))
			{
				try
				{
					showRobot(value);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
					output.errorMessage(e.Message);
				}
				Environment.Exit(0);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static void showRobot(String value) throws IllegalAccessException
		private static void showRobot(string value)
		{
			string robotString = getRobotString(value);
			Console.WriteLine(robotString);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static String getRobotString(String path) throws IllegalAccessException
		private static string getRobotString(string path)
		{
            File file = new File(path);
			Robot robot = PopulationDAOFileSystem.getRobotFromFile(file);
			return robot.showRobot();
		}

		private static void checkShowPopulation(Parameters parameters)
		{
			string value = parameters.getValue("showPopulation");
			if (!string.ReferenceEquals(value, null))
			{
				try
				{
					showPopulation(value);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
					output.errorMessage(e.Message);
				}
				Environment.Exit(0);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static void showPopulation(String path) throws IllegalAccessException
		private static void showPopulation(string path)
		{
			PopulationDAOFileSystem dao = new PopulationDAOFileSystem(path);
			Population population = PopulationFactory.getDefaultPopulation(dao);
			showHeader();
			showRobots(population);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static void showRobots(com.alphatica.genotick.population.Population population) throws IllegalAccessException
		private static void showRobots(Population population)
		{
			foreach (RobotInfo robotInfo in population.RobotInfoList)
			{
				string info = getRobotInfoString(robotInfo);
				Console.WriteLine(info);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static String getRobotInfoString(com.alphatica.genotick.population.RobotInfo robotInfo) throws IllegalAccessException
		private static string getRobotInfoString(RobotInfo robotInfo)
		{
			StringBuilder sb = new StringBuilder();
			string[] fields = robotInfo.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
			foreach (Field field in fields)
			{
				field.Accessible = true;
				if (!Modifier.isStatic(field.Modifiers))
				{
					object @object = field.get(robotInfo);
					if (sb.Length > 0)
					{
						sb.Append(",");
					}
					sb.Append(@object.ToString());
				}
			}
			return sb.ToString();
		}

		private static void showHeader()
		{
			Type infoClass = typeof(RobotInfo);
			IList<Field> fields = buildFields(infoClass);
			string line = buildLine(fields);
			Console.WriteLine(line);
		}

		private static IList<Field> buildFields(Type infoClass)
		{
			IList<Field> fields = new List<Field>();
			foreach (Field field in infoClass.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
			{
				if (!Modifier.isStatic(field.Modifiers))
				{
					fields.Add(field);
				}
			}
			return fields;
		}

		private static string buildLine(IList<Field> fields)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Field field in fields)
			{
				if (sb.Length > 0)
				{
					sb.Append(",");
				}
				sb.Append(field.Name);
			}
			return sb.ToString();
		}

		private static void setupExceptionHandler()
		{
			Thread.DefaultUncaughtExceptionHandler = output.createExceptionHandler();
		}

		private static void checkVersionRequest(Parameters parameters)
		{
			if (!string.ReferenceEquals(parameters.getValue("showVersion"), null))
			{
				Console.WriteLine(Main.VERSION);
				Environment.Exit(0);
			}
		}

		private static void checkYahoo(Parameters parameters)
		{
			string yahooValue = parameters.getValue("fixYahoo");
			if (string.ReferenceEquals(yahooValue, null))
			{
				return;
			}
			YahooFixer yahooFixer = new YahooFixer(yahooValue);
			yahooFixer.fixFiles(output);
			Environment.Exit(0);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static void getUserIO(com.alphatica.genotick.ui.Parameters parameters) throws IOException
		private static void getUserIO(Parameters parameters)
		{
			input = UserInputOutputFactory.getUserInput(parameters);
			if (input == null)
			{
				exit(errorCodes.NO_INPUT);
			}
			output = UserInputOutputFactory.getUserOutput(parameters);
			//noinspection ConstantConditions
			if (output == null)
			{
				exit(errorCodes.NO_OUTPUT);
			}
		}

		private static void checkReverse(Parameters parameters)
		{
			string reverseValue = parameters.getValue("reverse");
			if (string.ReferenceEquals(reverseValue, null))
			{
				return;
			}
			Reversal reversal = new Reversal(reverseValue,output);
			reversal.reverse();
			Environment.Exit(0);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static void checkSimulation(com.alphatica.genotick.ui.Parameters parameters) throws IllegalAccessException
		private static void checkSimulation(Parameters parameters)
		{
			if (!parameters.allConsumed())
			{
				output.errorMessage("Not all arguments processed: " + parameters.Unconsumed);
				exit(errorCodes.UNKNOWN_ARGUMENT);
			}
			Simulation simulation = new Simulation(output);
			input.Simulation = simulation;
			MainSettings settings = input.getSettings(output);
			MainAppData data = input.getData(settings.dataSettings,output);
			settings.validateTimePoints(data);
			simulation.start(settings,data);
		}


		private static void exit(errorCodes code)
		{
			Environment.Exit(code.Value);
		}
	}


}