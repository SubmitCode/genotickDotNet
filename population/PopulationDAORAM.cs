using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.population
{

	using RandomGenerator = com.alphatica.genotick.genotick.RandomGenerator;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	public class PopulationDAORAM : PopulationDAO
	{
		private readonly IDictionary<RobotName, Robot> map = new Dictionary<RobotName, Robot>();
		private readonly Random random;

		public PopulationDAORAM()
		{
			random = RandomGenerator.assignRandom();
		}
		public virtual IEnumerable<Robot> RobotList
		{
			get
			{
				return new IterableAnonymousInnerClass(this);
			}
		}

		private class IterableAnonymousInnerClass : IEnumerable<Robot>
		{
			private readonly PopulationDAORAM outerInstance;

			public IterableAnonymousInnerClass(PopulationDAORAM outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public virtual IEnumerator<Robot> GetEnumerator()
			{
				return outerInstance.map.Values.GetEnumerator();
			}
		}

		public virtual int AvailableRobotsCount
		{
			get
			{
				return map.Count;
			}
		}

		public virtual Robot getRobotByName(RobotName name)
		{
			return map[name];
		}

		public virtual void saveRobot(Robot robot)
		{
			if (robot.Name == null)
			{
				robot.Name = AvailableRobotName;
			}
			map[robot.Name] = robot;
		}

		public virtual void removeRobot(RobotName robotName)
		{
			map.Remove(robotName);
		}


		private RobotName AvailableRobotName
		{
			get
			{
				long l;
				RobotName name;
				bool nameExist;
				do
				{
					l = random.nextLong();
					if (l < 0)
					{
						l = -l;
					}
					name = new RobotName(l);
					nameExist = map.ContainsKey(name);
				} while (nameExist);
				return name;
			}
		}

		public virtual RobotName[] listRobotNames()
		{
			return map.Keys.toArray(new RobotName[map.Count]);
		}
	}

}