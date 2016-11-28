using System.Text;
using System.Reflection;

namespace com.alphatica.genotick.genotick
{

	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;

	public class MainSettings
	{

		public TimePoint startTimePoint = new TimePoint(0);
		public TimePoint endTimePoint = new TimePoint(long.MaxValue);
		public string populationDAO = "";
		public bool performTraining = true;
		public string dataSettings = Main.DEFAULT_DATA_DIR;
		public int populationDesiredSize = 1_000;
		public int processorInstructionLimit = 256;
		public double maximumDeathByAge = 0.01;
		public double maximumDeathByWeight = 0.1;
		public double probabilityOfDeathByAge = 0.5;
		public double probabilityOfDeathByWeight = 0.5;
		public double inheritedChildWeight = 0;
		public int dataMaximumOffset = 256;
		public int protectRobotsUntilOutcomes = 100;
		public double newInstructionProbability = 0.01;
		public double instructionMutationProbability = 0.01;
		public double skipInstructionProbability = 0.01;
		public long minimumOutcomesToAllowBreeding = 50;
		public long minimumOutcomesBetweenBreeding = 50;
		public bool killNonPredictingRobots = true;
		public double randomRobotsAtEachUpdate = 0.02;
		public double protectBestRobots = 0.02;
		public bool requireSymmetricalRobots = true;
		public double resultThreshold = 1;
		public int ignoreColumns = 0;

		private MainSettings()
		{
			/* Empty */
		}
		public static MainSettings Settings
		{
			get
			{
				return new MainSettings();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String getString() throws IllegalAccessException
		public virtual string String
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				Field[] fields = this.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
				foreach (Field field in fields)
				{
					sb.Append(field.Name).Append(" ").Append(field.get(this)).Append("\n");
				}
				return sb.ToString();
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("WeakerAccess") public void validateTimePoints(com.alphatica.genotick.data.MainAppData data)
		public virtual void validateTimePoints(MainAppData data)
		{
			TimePoint first = data.FirstTimePoint;
			TimePoint last = data.LastTimePoint;
			if (startTimePoint.CompareTo(first) < 0)
			{
				startTimePoint = first;
			}
			if (endTimePoint.CompareTo(last) > 0)
			{
				endTimePoint = last;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("WeakerAccess") public void validate()
		public virtual void validate()
		{
			ensure(startTimePoint.CompareTo(endTimePoint) <= 0, "End Time Point must be higher or equal Start Time Point");
			ensure(populationDesiredSize > 0, greaterThanZeroString("Population desired size"));
			ensure(dataMaximumOffset > 0, greaterThanZeroString("Data Maximum Offset"));
			ensure(processorInstructionLimit > 0, greaterThanZeroString("Processor Instruction Limit"));
			ensure(checkZeroToOne(maximumDeathByAge), zeroToOneString("Maximum Death by Age"));
			ensure(checkZeroToOne(maximumDeathByWeight), zeroToOneString("Maximum Death by Weight"));
			ensure(checkZeroToOne(probabilityOfDeathByAge), zeroToOneString("Probability Death by Age"));
			ensure(checkZeroToOne(inheritedChildWeight), zeroToOneString("Inherited Child's Weight"));
			ensure(protectRobotsUntilOutcomes >= 0, atLeastZeroString("Protect Robots until Outcomes"));
			ensure(checkZeroToOne(newInstructionProbability), zeroToOneString("New Instruction Probability"));
			ensure(checkZeroToOne(instructionMutationProbability), zeroToOneString("Instruction Mutation Probability"));
			ensure(checkZeroToOne(skipInstructionProbability), zeroToOneString("Skip Instruction Probability"));
			ensure(minimumOutcomesToAllowBreeding >= 0, atLeastZeroString("Minimum outcomes to allow breeding"));
			ensure(minimumOutcomesBetweenBreeding >= 0, atLeastZeroString("Minimum outcomes between breeding"));
			ensure(randomRobotsAtEachUpdate >= 0, zeroToOneString("Random Robots at Each Update"));
			ensure(protectBestRobots >= 0, zeroToOneString("Protect Best Robots"));
			ensure(resultThreshold >= 1,atLeastOneString("Result threshold"));
			ensure(ignoreColumns >= 0, atLeastZeroString("Ignore columns"));

		}
		private string atLeastZeroString(string s)
		{
			return s + " must be at least 0";
		}
		private string zeroToOneString(string s)
		{
			return s + " must be between 0.0 and 1.0";
		}
		private string greaterThanZeroString(string s)
		{
			return s + " must be greater than 0";
		}
		private string atLeastOneString(string s)
		{
			return s + " must be greater than 1";
		}
		private bool checkZeroToOne(double value)
		{
			return value >= 0 && value <= 1;
		}

		private void ensure(bool condition, string message)
		{
			if (!condition)
			{
				throw new System.ArgumentException(message);
			}
		}
	}

}