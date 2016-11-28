using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableNotEqualVariable : VarVarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3271032134612877777L;
		private const long serialVersionUID = 3271032134612877777L;

		private JumpIfVariableNotEqualVariable(JumpIfVariableNotEqualVariable i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableNotEqualVariable()
		public JumpIfVariableNotEqualVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableNotEqualVariable copy()
		{
			return new JumpIfVariableNotEqualVariable(this);
		}
	}

}