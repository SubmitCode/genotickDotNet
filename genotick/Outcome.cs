using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	public sealed class Outcome
	{
		public static readonly Outcome CORRECT = new Outcome("CORRECT", InnerEnum.CORRECT);
		public static readonly Outcome INCORRECT = new Outcome("INCORRECT", InnerEnum.INCORRECT);
		public static readonly Outcome OUT = new Outcome("OUT", InnerEnum.OUT);

		private static readonly IList<Outcome> valueList = new List<Outcome>();

		static Outcome()
		{
			valueList.Add(CORRECT);
			valueList.Add(INCORRECT);
			valueList.Add(OUT);
		}

		public enum InnerEnum
		{
			CORRECT,
			INCORRECT,
			OUT
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private Outcome(string name, InnerEnum innerEnum)
		{
			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}


		public static Outcome getOutcome(Prediction prediction, double actualChange)
		{
			if (prediction == Prediction.OUT)
			{
				return OUT;
			}
			return prediction.isCorrect(actualChange) ? CORRECT : INCORRECT;
		}

		public static IList<Outcome> values()
		{
			return valueList;
		}

		public InnerEnum InnerEnumValue()
		{
			return innerEnumValue;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static Outcome valueOf(string name)
		{
			foreach (Outcome enumInstance in Outcome.values())
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}

}