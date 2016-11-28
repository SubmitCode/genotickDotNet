using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveDataToVariable : DataVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3017704625520415010L;
		private const long serialVersionUID = 3017704625520415010L;

		private MoveDataToVariable(MoveDataToVariable i)
		{
			this.DataTableIndex = i.DataColumnIndex;
			this.DataOffsetIndex = i.DataOffsetIndex;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveDataToVariable()
		public MoveDataToVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveDataToVariable copy()
		{
			return new MoveDataToVariable(this);
		}

	}

}