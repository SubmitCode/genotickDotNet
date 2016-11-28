using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.killer
{

	using RandomGenerator = com.alphatica.genotick.genotick.RandomGenerator;
	using Population = com.alphatica.genotick.population.Population;
	using RobotInfo = com.alphatica.genotick.population.RobotInfo;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	internal class SimpleRobotKiller : RobotKiller
	{
		private RobotKillerSettings settings;
		private readonly Random random;
		private readonly UserOutput output;

		public static RobotKiller getInstance(UserOutput output)
		{
			return new SimpleRobotKiller(output);
		}
		private SimpleRobotKiller(UserOutput output)
		{
			random = RandomGenerator.assignRandom();
			this.output = output;
		}

		public virtual void killRobots(Population population, IList<RobotInfo> robotsInfos)
		{
			killNonPredictingRobots(population, robotsInfos);
			killNonSymmetricalRobots(population, robotsInfos);
			IList<RobotInfo> listCopy = new List<RobotInfo>(robotsInfos);
			removeProtectedRobots(population,listCopy);
			killRobotsByWeight(population, listCopy, robotsInfos);
			killRobotsByAge(population, listCopy, robotsInfos);
		}

		private void killNonSymmetricalRobots(Population population, IList<RobotInfo> list)
		{
			if (!settings.requireSymmetricalRobots)
			{
				return;
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				RobotInfo info = list[i];
				if (info.Bias != 0)
				{
					list.RemoveAt(i);
					population.removeRobot(info.Name);
				}
			}
		}

		private void killNonPredictingRobots(Population population, IList<RobotInfo> list)
		{
			if (!settings.killNonPredictingRobots)
			{
				return;
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				RobotInfo info = list[i];
				if (info.TotalPredictions == 0)
				{
					list.RemoveAt(i);
					population.removeRobot(info.Name);
				}
			}
		}

		private void removeProtectedRobots(Population population, IList<RobotInfo> list)
		{
			protectUntilOutcomes(list);
			protectBest(population, list);
		}

		private void protectBest(Population population, IList<RobotInfo> list)
		{
			if (settings.protectBestRobots > 0)
			{
				list.Sort(RobotInfo.comparatorByAbsoluteWeight);
				int i = (int)Math.Round(settings.protectBestRobots * population.DesiredSize);
				while (i-- > 0)
				{
					RobotInfo robotInfo = getLastFromList(list);
					if (robotInfo == null)
					{
						break;
					}
				}
			}
		}

		private void protectUntilOutcomes(IList<RobotInfo> list)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				RobotInfo robotInfo = list[i];
				if (robotInfo.TotalOutcomes < settings.protectRobotsUntilOutcomes)
				{
					list.RemoveAt(i);
				}
			}
		}

		public virtual RobotKillerSettings Settings
		{
			set
			{
				settings = value;
			}
		}

		private void killRobotsByAge(Population population, IList<RobotInfo> listCopy, IList<RobotInfo> originalList)
		{
			listCopy.Sort(RobotInfo.comparatorByAge);
			int numberToKill = (int)Math.Round(settings.maximumDeathByAge * originalList.Count);
			killRobots(listCopy,originalList,numberToKill,population,settings.probabilityOfDeathByAge);
		}

		private void killRobotsByWeight(Population population, IList<RobotInfo> listCopy, IList<RobotInfo> originalList)
		{
			if (population.haveSpaceToBreed())
			{
				return;
			}
			listCopy.Sort(RobotInfo.comparatorByAbsoluteWeight);
			listCopy.Reverse();
			int numberToKill = (int) Math.Round(settings.maximumDeathByWeight * originalList.Count);
			killRobots(listCopy,originalList,numberToKill,population,settings.probabilityOfDeathByWeight);
		}

		private int killRobots(IList<RobotInfo> listCopy, IList<RobotInfo> originalList, int numberToKill, Population population, double probability)
		{
			int numberKilled = 0;
			while (numberToKill-- > 0)
			{
				RobotInfo toKill = getLastFromList(listCopy);
				if (toKill == null)
				{
					return numberKilled;
				}
				if (random.NextDouble() < probability)
				{
					population.removeRobot(toKill.Name);
					originalList.Remove(toKill);
					numberKilled++;
				}
			}
			return numberKilled;
		}

		private RobotInfo getLastFromList(IList<RobotInfo> list)
		{
			int size = list.Count;
			if (size == 0)
			{
				return null;
			}
			return list.RemoveAt(size-1);
		}
	}

}