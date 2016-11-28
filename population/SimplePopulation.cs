using System.Collections.Generic;

namespace com.alphatica.genotick.population
{



	public class SimplePopulation : Population
	{
		private int desiredSize = 1024;
		private PopulationDAO dao;

		public virtual int DesiredSize
		{
			set
			{
				desiredSize = value;
			}
			get
			{
				return desiredSize;
			}
		}


		public virtual int Size
		{
			get
			{
				return dao.AvailableRobotsCount;
			}
		}

		public virtual PopulationDAO Dao
		{
			set
			{
				this.dao = value;
			}
		}

		public virtual void saveRobot(Robot robot)
		{
			dao.saveRobot(robot);
		}

		public virtual Robot getRobot(RobotName name)
		{
			return dao.getRobotByName(name);
		}

		public virtual void removeRobot(RobotName robotName)
		{
			dao.removeRobot(robotName);
		}

		public virtual IList<RobotInfo> RobotInfoList
		{
			get
			{
				IList<RobotInfo> list = new List<RobotInfo>(dao.AvailableRobotsCount);
				foreach (Robot robot in dao.RobotList)
				{
					RobotInfo robotInfo = new RobotInfo(robot);
					list.Add(robotInfo);
				}
				return list;
			}
		}

		public virtual bool haveSpaceToBreed()
		{
			return Size < DesiredSize;
		}

		public virtual void savePopulation(string path)
		{
			PopulationDAO fs = new PopulationDAOFileSystem(path);
			foreach (Robot robot in dao.RobotList)
			{
				fs.saveRobot(robot);
			}
		}

		public virtual RobotName[] listRobotsNames()
		{
			return dao.listRobotNames();
		}
	}

}