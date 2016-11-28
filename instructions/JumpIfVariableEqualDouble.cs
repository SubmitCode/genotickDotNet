using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableEqualDouble : VarDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3937406272874353714L;
		private const long serialVersionUID = 3937406272874353714L;

		private JumpIfVariableEqualDouble(JumpIfVariableEqualDouble i)
		{
			this.VariableArgument = i.VariableArgument;
			this.DoubleArgument = i.DoubleArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableEqualDouble()
		public JumpIfVariableEqualDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableEqualDouble copy()
		{
			return new JumpIfVariableEqualDouble(this);
		}
	}

}