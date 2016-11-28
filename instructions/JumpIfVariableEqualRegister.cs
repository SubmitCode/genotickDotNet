using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableEqualRegister : RegVarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8121933377560453966L;
		private const long serialVersionUID = -8121933377560453966L;

		private JumpIfVariableEqualRegister(JumpIfVariableEqualRegister i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableEqualRegister()
		public JumpIfVariableEqualRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableEqualRegister copy()
		{
			return new JumpIfVariableEqualRegister(this);
		}
	}

}