using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	using TimePointExecutor = com.alphatica.genotick.timepoint.TimePointExecutor;
	using TimePointStats = com.alphatica.genotick.timepoint.TimePointStats;
	using RobotBreeder = com.alphatica.genotick.breeder.RobotBreeder;
	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using RobotKiller = com.alphatica.genotick.killer.RobotKiller;
	using Population = com.alphatica.genotick.population.Population;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;

	public interface Engine
	{
		IList<TimePointStats> start(UserOutput output);

		void setSettings(EngineSettings engineSettings, TimePointExecutor timePointExecutor, MainAppData data, RobotKiller killer, RobotBreeder breeder, Population population);
	}

}