using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	using com.alphatica.genotick.population;

	public interface DataSetExecutor
	{

		IList<RobotResult> execute(IList<RobotData> robotDataList, Robot robot, RobotExecutor robotExecutor);

	}

}