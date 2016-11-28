using System.Collections.Generic;

namespace com.alphatica.genotick.population
{


	public interface Population
	{

		int DesiredSize {set;get;}


		int Size {get;}

		PopulationDAO Dao {set;}

		void saveRobot(Robot robot);

		Robot getRobot(RobotName key);

		void removeRobot(RobotName robotName);

		IList<RobotInfo> RobotInfoList {get;}

		bool haveSpaceToBreed();

		void savePopulation(string path);

		RobotName[] listRobotsNames();
	}

}