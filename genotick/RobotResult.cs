namespace com.alphatica.genotick.genotick
{

	using Robot = com.alphatica.genotick.population.Robot;
	using RobotName = com.alphatica.genotick.population.RobotName;

	public class RobotResult
	{

		private readonly Prediction prediction;
		private readonly RobotName name;
		private readonly RobotData data;
		private readonly double? weight;

		public RobotResult(Prediction prediction, Robot robot, RobotData data)
		{

			this.prediction = prediction;
			this.name = robot.Name;
			this.weight = robot.Weight;
			this.data = data;
		}

		public override string ToString()
		{
			return "Name: " + name.ToString() + " Prediction: " + prediction.ToString() + " Weight: " + weight.ToString();
		}

		public virtual Prediction Prediction
		{
			get
			{
				return prediction;
			}
		}

		public virtual double? Weight
		{
			get
			{
				return weight;
			}
		}

		public virtual RobotData Data
		{
			get
			{
				return data;
			}
		}
	}

}