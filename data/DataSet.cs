using System.Collections.Generic;

namespace com.alphatica.genotick.data
{


	using RobotData = com.alphatica.genotick.genotick.RobotData;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;


	public class DataSet
	{
		private readonly TimePoint[] timePoints;
		private readonly IList<double []> values;
		private readonly DataSetName name;

		public DataSet(IList<Number []> lines, string name)
		{
			this.name = new DataSetName(name);
			timePoints = new TimePoint[lines.Count];
			values = new List<>();

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int firstLineCount = lines.get(0).length;
			int firstLineCount = lines[0].Length;
			createValuesArrays(lines.Count,firstLineCount);
			int lineNumber = 0;
			foreach (Number[] line in lines)
			{
				lineNumber++;
				checkNumberOfFieldsInLine(lineNumber,line,firstLineCount);
				fillFirstNumberAsTimePoint(lineNumber, line);
				fillValuesArrays(lineNumber, line, firstLineCount);
			}
		}

		public virtual DataSetName Name
		{
			get
			{
				return name;
			}
		}

		public virtual RobotData getRobotData(TimePoint timePoint)
		{
			int i = Arrays.binarySearch(timePoints,timePoint);
			if (i < 0)
			{
				return RobotData.createEmptyData(name);
			}
			else
			{
				return createDataUpToTimePoint(i);
			}
		}


		public virtual double calculateFutureChange(TimePoint timePoint)
		{
			int i = Arrays.binarySearch(timePoints,timePoint);
			if (i < 0)
			{
			   throw NoDataForTimePointException.instance;
			}
			int startIndex = i + 1;
			int endIndex = startIndex + 1;
			double[] array = values[0];
			if (endIndex >= array.Length)
			{
				throw NoDataForTimePointException.instance;
			}
			double startValue = array[startIndex];
			double endValue = array[endIndex];
			return 100.0 * (endValue - startValue) / startValue;
		}

		private void fillValuesArrays(int lineNumber, Number[] line, int firstLineCount)
		{
			for (int j = 1; j < firstLineCount; j++)
			{
				values[j - 1][lineNumber - 1] = line[j].doubleValue();
			}
		}

		private void fillFirstNumberAsTimePoint(int lineNumber, Number[] line)
		{
			TimePoint timePoint = new TimePoint(line[0].longValue());
			// Arrays start indexing from 0, but humans count text lines starting from 1.
			// New timePoint will be assigned to index = lineNumber -1, so
			// we have to check what happened two lines ago!
			if (lineNumber >= 2 && timePoint.CompareTo(timePoints[lineNumber - 2]) <= 0)
			{
				throw new DataException("Time (first number) is equal or less than previous. Line: " + lineNumber);
			}
			timePoints[lineNumber - 1] = timePoint;
		}

		private void checkNumberOfFieldsInLine(int lineNumber, Number[] line, int firstLineCount)
		{
			if (line.Length != firstLineCount)
			{
				throw new DataException("Invalid number of fields in line: " + lineNumber);
			}
		}

		private void createValuesArrays(int size, int firstLineCount)
		{
			for (int i = 0; i < firstLineCount - 1; i++)
			{
				values.Add(new double[size]);
			}
		}

		private RobotData createDataUpToTimePoint(int i)
		{
			IList<double []> list = new List<double []>();
			foreach (double[] original in values)
			{
				double[] copy = copyReverseArray(original, i);
				list.Add(copy);
			}
			try
			{
				double? futureChange = calculateFutureChange(timePoints[i]);
				return RobotData.createData(list, name, futureChange.Value);
			}
			catch (NoDataForTimePointException)
			{
				return RobotData.createEmptyData(name);
			}
		}

		private double[] copyReverseArray(double[] original, int i)
		{
			double[] array = new double[i + 1];
			for (int k = 0; k <= i; k++)
			{
				array[k] = original[i - k];
			}
			return array;
		}

		public virtual int LinesCount
		{
			get
			{
				return timePoints.Length;
			}
		}

		public virtual Number [] getLine(int lineNumber)
		{
			Number[] line = new Number[1 + values.Count];
			line[0] = timePoints[lineNumber].Value;
			for (int i = 1; i < line.Length; i++)
			{
				line[i] = values[i - 1][lineNumber];
			}
			return line;
		}

		public virtual TimePoint FirstTimePoint
		{
			get
			{
				return timePoints[0];
			}
		}

		public virtual TimePoint LastTimePoint
		{
			get
			{
				return timePoints[timePoints.Length - 1];
			}
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}

			DataSet dataSet = (DataSet) o;

			return name.Equals(dataSet.name);

		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}
	}

}