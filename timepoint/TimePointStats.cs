using System;
using System.Collections.Generic;
using System.Text;

namespace com.alphatica.genotick.timepoint
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using Prediction = com.alphatica.genotick.genotick.Prediction;


	[Serializable]
	public class TimePointStats
	{

		private const long serialVersionUID = -5355094455686373969L;
		private readonly Dictionary<DataSetName, SetStats> stats;
		private readonly TimePoint timePoint;

		public virtual double PercentEarned
		{
			get
			{
				if (stats.Count == 0)
				{
					return 0;
				}
				double percent = 0;
				foreach (SetStats setStats in stats.Values)
				{
					percent += setStats.TotalPercent;
				}
				return percent / stats.Count;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public TimePoint getTimePoint()
		public virtual TimePoint TimePoint
		{
			get
			{
				return timePoint;
			}
		}

		public static TimePointStats getNewStats(TimePoint timePoint)
		{
			return new TimePointStats(timePoint);
		}

		private TimePointStats(TimePoint timePoint)
		{
			stats = new Dictionary<>();
			this.timePoint = new TimePoint(timePoint);
		}

		public virtual void update(DataSetName setName, double actualFutureChange, Prediction prediction)
		{
			SetStats stats = getSetStats(setName);
			stats.update(actualFutureChange,prediction);
		}

		public virtual ISet<KeyValuePair<DataSetName, SetStats>> listSets()
		{
			return stats.SetOfKeyValuePairs();
		}
		private SetStats getSetStats(DataSetName setName)
		{
			SetStats stat = stats[setName];
			if (stat == null)
			{
				stat = new SetStats();
				stats[setName] = stat;
			}
			return stat;
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Stats for time point: ");
			sb.Append(timePoint.ToString());
			sb.Append(Environment.NewLine);
			foreach (KeyValuePair<DataSetName, SetStats> entry in stats.SetOfKeyValuePairs())
			{
				appendStats(sb,entry);
			}
			double percentPredicted = 0;
			foreach (KeyValuePair<DataSetName, SetStats> entry in stats.SetOfKeyValuePairs())
			{
				percentPredicted += entry.Value.TotalPercent;
			}
			sb.Append("Total percent predicted: ");
			sb.Append(percentPredicted);
			sb.Append(Environment.NewLine);
			return sb.ToString();
		}

		private void appendStats(StringBuilder sb, KeyValuePair<DataSetName, SetStats> entry)
		{
			sb.Append("Data set: ");
			sb.Append(entry.Key.ToString());
			sb.Append(" ");
			sb.Append(entry.Value.ToString());
			sb.Append(Environment.NewLine);
		}

	}

}