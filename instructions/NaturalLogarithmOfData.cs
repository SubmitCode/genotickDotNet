using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class NaturalLogarithmOfData : DataRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -3598160310785452494L;
		private const long serialVersionUID = -3598160310785452494L;

		private NaturalLogarithmOfData(NaturalLogarithmOfData i)
		{
			this.DataOffsetIndex = i.DataOffsetIndex;
			this.DataTableIndex = i.DataColumnIndex;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public NaturalLogarithmOfData()
		public NaturalLogarithmOfData()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override NaturalLogarithmOfData copy()
		{
			return new NaturalLogarithmOfData(this);
		}
	}

}