using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableGreaterThanVariable : VarVarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 6092048224711211254L;
		private const long serialVersionUID = 6092048224711211254L;

		private JumpIfVariableGreaterThanVariable(JumpIfVariableGreaterThanVariable i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableGreaterThanVariable()
		public JumpIfVariableGreaterThanVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableGreaterThanVariable copy()
		{
			return new JumpIfVariableGreaterThanVariable(this);
		}
	}

}