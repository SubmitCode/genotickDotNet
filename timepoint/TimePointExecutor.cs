using System.Collections.Generic;

namespace com.alphatica.genotick.timepoint
{

	using DataSetExecutor = com.alphatica.genotick.genotick.DataSetExecutor;
	using RobotData = com.alphatica.genotick.genotick.RobotData;
	using Population = com.alphatica.genotick.population.Population;
	using RobotInfo = com.alphatica.genotick.population.RobotInfo;
	using RobotExecutorFactory = com.alphatica.genotick.processor.RobotExecutorFactory;

	public interface TimePointExecutor
	{
		IList<RobotInfo> RobotInfos {get;}

		TimePointResult execute(IList<RobotData> robotDataList, Population population, bool updateRobots);

		void setSettings(DataSetExecutor dataSetExecutor, RobotExecutorFactory robotExecutorFactory);
	}

}