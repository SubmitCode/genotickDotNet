namespace com.alphatica.genotick.killer
{

	using UserOutput = com.alphatica.genotick.ui.UserOutput;

	public class RobotKillerFactory
	{
		public static RobotKiller getDefaultRobotKiller(RobotKillerSettings killerSettings, UserOutput output)
		{
			RobotKiller killer = SimpleRobotKiller.getInstance(output);
			killer.Settings = killerSettings;
			return killer;
		}
	}

}