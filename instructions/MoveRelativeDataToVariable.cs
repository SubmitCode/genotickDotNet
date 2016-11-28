using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveRelativeDataToVariable : DataVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 1308815201295846632L;
		private const long serialVersionUID = 1308815201295846632L;

		private MoveRelativeDataToVariable(MoveRelativeDataToVariable i)
		{
			this.DataOffsetIndex = i.DataOffsetIndex;
			this.DataTableIndex = i.DataColumnIndex;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveRelativeDataToVariable()
		public MoveRelativeDataToVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveRelativeDataToVariable copy()
		{
			return new MoveRelativeDataToVariable(this);
		}

	}

}