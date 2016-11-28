using System.Collections.Generic;

namespace com.alphatica.genotick.killer
{

	using Population = com.alphatica.genotick.population.Population;
	using RobotInfo = com.alphatica.genotick.population.RobotInfo;

	public interface RobotKiller
	{
		void killRobots(Population population, IList<RobotInfo> robotsInfos);

		RobotKillerSettings Settings {set;}
	}

}