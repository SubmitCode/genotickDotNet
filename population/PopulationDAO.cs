namespace com.alphatica.genotick.population
{

	public interface PopulationDAO
	{

		IEnumerable<Robot> RobotList {get;}

		int AvailableRobotsCount {get;}

		Robot getRobotByName(RobotName name);

		void saveRobot(Robot robot);

		void removeRobot(RobotName robotName);

		RobotName[] listRobotNames();
	}

}