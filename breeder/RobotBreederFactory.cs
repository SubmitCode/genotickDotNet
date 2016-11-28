namespace com.alphatica.genotick.breeder
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	public class RobotBreederFactory
	{
		public static RobotBreeder getDefaultBreeder(BreederSettings breederSettings, Mutator mutator)
		{
			RobotBreeder breeder = SimpleBreeder.Instance;
			breeder.setSettings(breederSettings,mutator);
			return breeder;
		}
	}

}