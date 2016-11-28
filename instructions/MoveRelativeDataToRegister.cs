using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveRelativeDataToRegister : DataRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -2247072351675972683L;
		private const long serialVersionUID = -2247072351675972683L;

		private MoveRelativeDataToRegister(MoveRelativeDataToRegister i)
		{
			this.DataOffsetIndex = i.DataOffsetIndex;
			this.DataTableIndex = i.DataColumnIndex;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveRelativeDataToRegister()
		public MoveRelativeDataToRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveRelativeDataToRegister copy()
		{
			return new MoveRelativeDataToRegister(this);
		}

	}

}