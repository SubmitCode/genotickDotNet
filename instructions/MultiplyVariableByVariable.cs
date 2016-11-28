using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MultiplyVariableByVariable : VarVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -2530246252784080647L;
		private const long serialVersionUID = -2530246252784080647L;

		private MultiplyVariableByVariable(MultiplyVariableByVariable i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MultiplyVariableByVariable()
		public MultiplyVariableByVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MultiplyVariableByVariable copy()
		{
			return new MultiplyVariableByVariable(this);
		}

	}

}