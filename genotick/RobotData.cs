using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using NotEnoughDataException = com.alphatica.genotick.processor.NotEnoughDataException;


	public class RobotData
	{
		private readonly IList<double[]> data;
		private readonly double actualChange;
		private readonly DataSetName name;

		public static RobotData createData(IList<double[]> newData, DataSetName name, double actualChange)
		{
			return new RobotData(newData,name,actualChange);
		}

		public static RobotData createData(IList<double[]> newData, DataSetName name)
		{
			return createData(newData, name, Double.NaN);
		}

		public static RobotData createEmptyData(DataSetName name)
		{
			IList<double []> list = new List<double []>();
			list.Add(new double[0]);
			return createData(list,name,Double.NaN);
		}

		private RobotData(IList<double[]> newData, DataSetName name, double actualChange)
		{
			data = newData;
			this.name = name;
			this.actualChange = actualChange;
		}

		public virtual double getData(int dataColumn, int dataOffset)
		{
			if (dataOffset >= data[dataColumn].Length)
			{
				throw new NotEnoughDataException();
			}
			else
			{
				return data[dataColumn][dataOffset];
			}
		}

		public virtual DataSetName Name
		{
			get
			{
				return name;
			}
		}

		public virtual bool Empty
		{
			get
			{
				return data[0].Length == 0;
			}
		}

		public virtual double? ActualChange
		{
			get
			{
				return actualChange;
			}
		}

		public virtual int Columns
		{
			get
			{
				return data.Count;
			}
		}
	}

}