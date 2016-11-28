using System;

namespace com.alphatica.genotick.timepoint
{

	using Outcome = com.alphatica.genotick.genotick.Outcome;
	using Prediction = com.alphatica.genotick.genotick.Prediction;

	[Serializable]
	public class SetStats
	{
		private const long serialVersionUID = 4443286273783452188L;
		private double totalPercentPredicted;
		private double totalPercentMispredicted;

		public SetStats()
		{
		}

		/// <summary>
		/// Updates stats for SetStats.name
		/// </summary>
		/// <param name="actualFutureChange"> actual change of data in the future </param>
		/// <param name="prediction">         predicted direction (up for positive values, down for negative) </param>
		public virtual void update(double? actualFutureChange, Prediction prediction)
		{
			Outcome outcome = Outcome.getOutcome(prediction, actualFutureChange);
			switch (outcome.InnerEnumValue())
			{
				case Outcome.InnerEnum.CORRECT:
					totalPercentPredicted += Math.Abs(actualFutureChange);
					break;
				case Outcome.InnerEnum.INCORRECT:
					totalPercentMispredicted += Math.Abs(actualFutureChange);
					break;
			}
		}

		public override string ToString()
		{
			return "Predicted %: " + (totalPercentPredicted - totalPercentMispredicted).ToString();
		}

		public virtual double TotalPercent
		{
			get
			{
				return totalPercentPredicted - totalPercentMispredicted;
			}
		}
	}

}