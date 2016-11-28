using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class DivideVariableByVariable : VarVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 2684230146996510206L;
		private const long serialVersionUID = 2684230146996510206L;

		private DivideVariableByVariable(DivideVariableByVariable i)
		{
			this.Variable2Argument = i.Variable2Argument;
			this.Variable1Argument = i.Variable1Argument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public DivideVariableByVariable()
		public DivideVariableByVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override DivideVariableByVariable copy()
		{
			return new DivideVariableByVariable(this);
		}

	}

}