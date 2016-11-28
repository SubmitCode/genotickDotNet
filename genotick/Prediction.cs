using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{

	public sealed class Prediction
	{
		public static readonly Prediction UP = new Prediction("UP", InnerEnum.UP, 1);
		public static readonly Prediction DOWN = new Prediction("DOWN", InnerEnum.DOWN, -1);
		public static readonly Prediction OUT = new Prediction("OUT", InnerEnum.OUT, 0);

		private static readonly IList<Prediction> valueList = new List<Prediction>();

		static Prediction()
		{
			valueList.Add(UP);
			valueList.Add(DOWN);
			valueList.Add(OUT);
		}

		public enum InnerEnum
		{
			UP,
			DOWN,
			OUT
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;
		private readonly double value;

		internal Prediction(string name, InnerEnum innerEnum, double value)
		{
			this.value = value;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}
		public static Prediction getPrediction(double change)
		{
			if (change > 0)
			{
				return Prediction.UP;
			}
			if (change < 0)
			{
				return Prediction.DOWN;
			}
			return Prediction.OUT;
		}

		public bool isCorrect(double actualFutureChange)
		{
			return actualFutureChange * value > 0;
		}

		public override string ToString()
		{
			return name();
		}

		public static IList<Prediction> values()
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

		public static Prediction valueOf(string name)
		{
			foreach (Prediction enumInstance in Prediction.values())
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