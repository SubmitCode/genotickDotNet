using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SubtractVariableFromVariable : VarVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5692114758846719358L;
		private const long serialVersionUID = -5692114758846719358L;

		private SubtractVariableFromVariable(SubtractVariableFromVariable i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SubtractVariableFromVariable()
		public SubtractVariableFromVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SubtractVariableFromVariable copy()
		{
			return new SubtractVariableFromVariable(this);
		}

	}

}