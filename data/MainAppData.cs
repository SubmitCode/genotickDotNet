using System.Collections.Generic;

namespace com.alphatica.genotick.data
{

	using RobotData = com.alphatica.genotick.genotick.RobotData;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;

	public class MainAppData
	{
		private readonly IDictionary<DataSetName, DataSet> sets;

		public MainAppData()
		{
			sets = new Dictionary<>();
		}

		public virtual void addDataSet(DataSet set)
		{
			sets[set.Name] = set;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public List<com.alphatica.genotick.genotick.RobotData> prepareRobotDataList(final com.alphatica.genotick.timepoint.TimePoint timePoint)
		public virtual IList<RobotData> prepareRobotDataList(TimePoint timePoint)
		{
			IList<RobotData> list = Collections.synchronizedList(new List<RobotData>());
			sets.SetOfKeyValuePairs().ForEach((KeyValuePair<DataSetName, DataSet> entry) =>
				/* Ignored */
		{
			try
			{
				RobotData robotData = entry.Value.getRobotData(timePoint);
				if (!robotData.Empty)
				{
					list.Add(robotData);
				}
			}
			catch (NoDataForTimePointException)
			{
			}
		});
			return list;
		}

		public virtual double getActualChange(DataSetName name, TimePoint timePoint)
		{
			return sets[name].calculateFutureChange(timePoint);
		}

		public virtual TimePoint FirstTimePoint
		{
			get
			{
				if (sets.Count == 0)
				{
					return null;
				}
				TimePoint firstTimePoint = null;
				foreach (DataSet set in sets.Values)
				{
					TimePoint first = set.FirstTimePoint;
					if (firstTimePoint == null)
					{
						firstTimePoint = first;
					}
					else if (first.CompareTo(firstTimePoint) < 0)
					{
						firstTimePoint = first;
					}
				}
				return firstTimePoint;
			}
		}

		public virtual TimePoint LastTimePoint
		{
			get
			{
				if (sets.Count == 0)
				{
					return null;
				}
				TimePoint lastTimePoint = null;
				foreach (DataSet set in sets.Values)
				{
					TimePoint last = set.LastTimePoint;
					if (lastTimePoint == null)
					{
						lastTimePoint = last;
					}
					else if (last.CompareTo(lastTimePoint) > 0)
					{
						lastTimePoint = last;
					}
				}
				return lastTimePoint;
			}
		}

		public virtual ICollection<DataSet> listSets()
		{
			return sets.Values;
		}


		public virtual bool Empty
		{
			get
			{
				return sets.Count == 0;
			}
		}
	}

}