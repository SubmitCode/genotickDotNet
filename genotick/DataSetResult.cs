namespace com.alphatica.genotick.genotick
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;

	public class DataSetResult
	{
		private readonly DataSetName name;
		private double weightUp;
		private double weightOut;
		private int countOut;
		private double weightDown;
		private int countDown;
		private int countUp;

		public DataSetResult(DataSetName name)
		{
			this.name = name;
		}

		public virtual void addResult(RobotResult robotResult)
		{
			double? weight = robotResult.Weight;
			if (double.IsNaN(weight))
			{
				return;
			}
			processWeight(robotResult);
		}

		public virtual DataSetName Name
		{
			get
			{
				return name;
			}
		}

		private void processWeight(RobotResult robotResult)
		{
			if (robotResult.Weight > 0)
			{
				switch (robotResult.Prediction)
				{
					case UP:
						recordUp(robotResult.Weight.Value);
						break;
					case DOWN:
						recordDown(robotResult.Weight.Value);
						break;
					case OUT:
						recordOut(robotResult.Weight.Value);
					break;
				}
			}
			if (robotResult.Weight < 0)
			{
				switch (robotResult.Prediction)
				{
					case UP:
						recordDown(-robotResult.Weight.Value);
						break;
					case DOWN:
						recordUp(-robotResult.Weight.Value);
						break;
					case OUT:
						recordOut(robotResult.Weight.Value);
					break;
				}
			}
		}

		private void recordOut(double weight)
		{
			weightOut += weight;
			countOut++;
		}

		private void recordDown(double weight)
		{
			weightDown += weight;
			countDown++;
		}

		private void recordUp(double weight)
		{
			weightUp += weight;
			countUp++;
		}

		internal virtual Prediction getCumulativePrediction(double threshold)
		{
			double direction = weightUp - weightDown;
			double directionAfterThreshold = applyThreshold(direction,threshold);
			if (direction * directionAfterThreshold < 0)
			{
				return Prediction.OUT;
			}
			return Prediction.getPrediction(directionAfterThreshold);
		}

		private double applyThreshold(double direction, double threshold)
		{
			if (threshold == 1)
			{
				return direction;
			}
			double localWeightUp = weightUp;
			double localWeightDown = weightDown;
			if (direction > 0)
			{
				localWeightUp /= threshold;
			}
			if (direction < 0)
			{
				localWeightDown /= threshold;
			}
			return localWeightUp - localWeightDown;
		}

	}

}