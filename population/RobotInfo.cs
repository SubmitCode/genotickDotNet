using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.population
{


	public class RobotInfo
	{
		public static readonly IComparer<RobotInfo> comparatorByAge = new AgeComparator();
		public static readonly IComparer<RobotInfo> comparatorByAbsoluteWeight = new AbsoluteWeightComparator();
		private static readonly DecimalFormat format = new DecimalFormat("0.00");
		private readonly RobotName name;
		private readonly double weight;
		private readonly long lastChildOutcomes;
		private readonly long totalChildren;
		private readonly long length;
		private readonly int totalPredictions;
		private readonly int totalOutcomes;
		private readonly int bias;

		public override string ToString()
		{
			return name.ToString() + ": Outcomes: " + totalPredictions.ToString() + " weight: " + format.format(weight) + " bias: " + bias.ToString() + " length: " + length.ToString() + " totalChildren: " + totalChildren.ToString();
		}

		public virtual RobotName Name
		{
			get
			{
				return name;
			}
		}

		public virtual double Weight
		{
			get
			{
				return weight;
			}
		}

		public virtual int TotalPredictions
		{
			get
			{
				return totalPredictions;
			}
		}

		public RobotInfo(Robot robot)
		{
			name = new RobotName(robot.Name.Name);
			weight = robot.Weight;
			lastChildOutcomes = robot.OutcomesAtLastChild;
			totalChildren = robot.TotalChildren;
			length = robot.Length;
			totalPredictions = robot.TotalPredictions;
			totalOutcomes = robot.TotalOutcomes;
			bias = robot.Bias;
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("BooleanMethodIsAlwaysInverted") public boolean canBeParent(long minimumParentAge, long timeBetweenChildren)
		public virtual bool canBeParent(long minimumParentAge, long timeBetweenChildren)
		{
			if (totalPredictions < minimumParentAge)
			{
				return false;
			}
			long outcomesSinceLastChild = totalPredictions - lastChildOutcomes;
			return outcomesSinceLastChild >= timeBetweenChildren;
		}

		public virtual int TotalOutcomes
		{
			get
			{
				return totalOutcomes;
			}
		}

		public virtual int Bias
		{
			get
			{
				return bias;
			}
		}

		private static double getTotalWeight(IList<RobotInfo> list)
		{
			double weight = 0;
			foreach (RobotInfo robotInfo in list)
			{
				weight += Math.Abs(robotInfo.Weight);
			}
			return weight;
		}

		public static double getAverageWeight(IList<RobotInfo> list)
		{
			if (list.Count == 0)
			{
				return 0;
			}
			else
			{
				return getTotalWeight(list) / list.Count;
			}
		}

		public static double getAverageLength(IList<RobotInfo> robotsInfos)
		{
			if (robotsInfos.Count == 0)
			{
				return 0;
			}
			double sum = 0;
			foreach (RobotInfo robotInfo in robotsInfos)
			{
				sum += robotInfo.length;
			}
			return sum / robotsInfos.Count;
		}
	}

}