namespace com.alphatica.genotick.population
{

	using MainSettings = com.alphatica.genotick.genotick.MainSettings;

	public class RobotExecutorSettings
	{
		public readonly int instructionLimit;

		public RobotExecutorSettings(MainSettings settings)
		{
			instructionLimit = settings.processorInstructionLimit;
		}
	}

}