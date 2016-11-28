using System;

namespace com.alphatica.genotick.timepoint
{

	[Serializable]
	public class TimePoint : IComparable<TimePoint>
	{

		private const long serialVersionUID = -6541300869299964665L;
		private readonly long value;
		public TimePoint(long i)
		{
			this.value = i;
		}

		public TimePoint(TimePoint startTimePoint) : this(startTimePoint.value)
		{
		}

		public override string ToString()
		{
			return Convert.ToString(value);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public int compareTo(@SuppressWarnings("NullableProblems") TimePoint timePoint)
		public virtual int CompareTo(("NullableProblems") TimePoint timePoint)
		{
			if (this.value > timePoint.value)
			{
				return 1;
			}
			else if (this.value < timePoint.value)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}

		public virtual long Value
		{
			get
			{
				return value;
			}
		}

		public virtual TimePoint next()
		{
			return new TimePoint(value + 1);
		}
	}

}