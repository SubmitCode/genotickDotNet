using System.Collections.Generic;

namespace com.alphatica.genotick.timepoint
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using DataSetResult = com.alphatica.genotick.genotick.DataSetResult;
	using RobotResult = com.alphatica.genotick.genotick.RobotResult;


	public class TimePointResult
	{
		private readonly IDictionary<DataSetName, DataSetResult> dataSetResultMap;

		public TimePointResult()
		{
			dataSetResultMap = new Dictionary<>();
		}

		public virtual void addRobotResult(RobotResult robotResult)
		{
			DataSetName name = robotResult.Data.Name;
			DataSetResult dataSetResult = getDataSetResult(name);
			dataSetResult.addResult(robotResult);
		}

		private DataSetResult getDataSetResult(DataSetName name)
		{
			DataSetResult dataSetResult = dataSetResultMap[name];
			if (dataSetResult == null)
			{
				dataSetResult = new DataSetResult(name);
				dataSetResultMap[name] = dataSetResult;
			}
			return dataSetResult;
		}

		public virtual DataSetResult[] listDataSetResults()
		{
			DataSetResult[] array = new DataSetResult[dataSetResultMap.Count];
			int i = 0;
			foreach (KeyValuePair<DataSetName, DataSetResult> entry in dataSetResultMap.SetOfKeyValuePairs())
			{
				array[i++] = entry.Value;
			}
			return array;
		}
	}

}