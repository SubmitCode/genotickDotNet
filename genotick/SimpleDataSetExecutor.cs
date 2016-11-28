using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	using Robot = com.alphatica.genotick.population.Robot;
	using RobotExecutor = com.alphatica.genotick.population.RobotExecutor;


	public class SimpleDataSetExecutor : DataSetExecutor
	{


		public virtual IList<RobotResult> execute(IList<RobotData> robotDataList, Robot robot, RobotExecutor robotExecutor)
		{
			IList<RobotResult> robotResultList = new List<RobotResult>(robotDataList.Count);
			foreach (RobotData robotData in robotDataList)
			{
				Prediction prediction = robotExecutor.executeRobot(robotData, robot);
				RobotResult result = new RobotResult(prediction, robot, robotData);
				robotResultList.Add(result);
			}
			return robotResultList;
		}

	}

}