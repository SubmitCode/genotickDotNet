using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{


	internal sealed class errorCodes
	{
		public static readonly errorCodes NO_INPUT = new errorCodes("NO_INPUT", InnerEnum.NO_INPUT, 1);
		public static readonly errorCodes UNKNOWN_ARGUMENT = new errorCodes("UNKNOWN_ARGUMENT", InnerEnum.UNKNOWN_ARGUMENT, 2);
		public static readonly errorCodes NO_OUTPUT = new errorCodes("NO_OUTPUT", InnerEnum.NO_OUTPUT, 3);

		private static readonly IList<errorCodes> valueList = new List<errorCodes>();

		static errorCodes()
		{
			valueList.Add(NO_INPUT);
			valueList.Add(UNKNOWN_ARGUMENT);
			valueList.Add(NO_OUTPUT);
		}

		public enum InnerEnum
		{
			NO_INPUT,
			UNKNOWN_ARGUMENT,
			NO_OUTPUT
		}

		private readonly string nameValue;
		private readonly int ordinalValue;
		private readonly InnerEnum innerEnumValue;
		private static int nextOrdinal = 0;

		private readonly int code;

		internal errorCodes(string name, InnerEnum innerEnum, int code)
		{
			this.code = code;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int Value
		{
			get
			{
				return code;
			}
		}

		public static IList<errorCodes> values()
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

		public static errorCodes valueOf(string name)
		{
			foreach (errorCodes enumInstance in errorCodes.values())
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