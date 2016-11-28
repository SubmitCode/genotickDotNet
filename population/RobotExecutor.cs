namespace com.alphatica.genotick.population
{

	using Prediction = com.alphatica.genotick.genotick.Prediction;
	using RobotData = com.alphatica.genotick.genotick.RobotData;

	public interface RobotExecutor
	{

		Prediction executeRobot(RobotData robotData, Robot robot);

		RobotExecutorSettings Settings {set;}
	}

	public static class RobotExecutor_Fields
	{
		public const sbyte totalRegisters = 4;
	}

}