using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableNotEqualDouble : VarDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3542351953333254754L;
		private const long serialVersionUID = 3542351953333254754L;

		private JumpIfVariableNotEqualDouble(JumpIfVariableNotEqualDouble i)
		{
			this.VariableArgument = i.VariableArgument;
			this.DoubleArgument = i.DoubleArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableNotEqualDouble()
		public JumpIfVariableNotEqualDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableNotEqualDouble copy()
		{
			return new JumpIfVariableNotEqualDouble(this);
		}
	}

}