using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.population
{


	[Serializable]
	internal class AbsoluteWeightComparator : IComparer<RobotInfo>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 4466317313399016583L;
		private const long serialVersionUID = 4466317313399016583L;

		public virtual int Compare(RobotInfo robotInfo1, RobotInfo robotInfo2)
		{
			return robotInfo1.Weight.CompareTo(robotInfo2.Weight);
		}
	}

}