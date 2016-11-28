using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveDataToRegister : DataRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 6441937261061215492L;
		private const long serialVersionUID = 6441937261061215492L;

		private MoveDataToRegister(MoveDataToRegister i)
		{
			this.DataOffsetIndex = i.DataOffsetIndex;
			this.DataTableIndex = i.DataColumnIndex;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveDataToRegister()
		public MoveDataToRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveDataToRegister copy()
		{
			return new MoveDataToRegister(this);
		}

	}

}