namespace com.alphatica.genotick.instructions
{

	using RobotExecutor = com.alphatica.genotick.population.RobotExecutor;

	internal class Registers
	{
		public static sbyte validateRegister(sbyte register)
		{
			return (sbyte)((register < 0 ? -register : register) % com.alphatica.genotick.population.RobotExecutor_Fields.totalRegisters);
		}
	}

}