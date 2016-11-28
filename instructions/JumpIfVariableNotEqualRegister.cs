using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableNotEqualRegister : RegVarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 196783147119700331L;
		private const long serialVersionUID = 196783147119700331L;

		private JumpIfVariableNotEqualRegister(JumpIfVariableNotEqualRegister i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableNotEqualRegister()
		public JumpIfVariableNotEqualRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableNotEqualRegister copy()
		{
			return new JumpIfVariableNotEqualRegister(this);
		}
	}

}