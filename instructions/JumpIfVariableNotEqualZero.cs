using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableNotEqualZero : VarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5411560101077877447L;
		private const long serialVersionUID = 5411560101077877447L;

		private JumpIfVariableNotEqualZero(JumpIfVariableNotEqualZero i)
		{
			this.VariableArgument = i.VariableArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableNotEqualZero()
		public JumpIfVariableNotEqualZero()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableNotEqualZero copy()
		{
			return new JumpIfVariableNotEqualZero(this);
		}
	}

}