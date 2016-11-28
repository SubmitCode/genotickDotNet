using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.population
{


	[Serializable]
	internal class AgeComparator : IComparer<RobotInfo>
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 8272762774160538039L;
		private const long serialVersionUID = 8272762774160538039L;

		public virtual int Compare(RobotInfo robotInfo1, RobotInfo robotInfo2)
		{
			return robotInfo1.TotalOutcomes - robotInfo2.TotalOutcomes;
		}
	}

}