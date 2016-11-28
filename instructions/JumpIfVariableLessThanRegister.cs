using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableLessThanRegister : RegVarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -4297622848412859898L;
		private const long serialVersionUID = -4297622848412859898L;

		private JumpIfVariableLessThanRegister(JumpIfVariableLessThanRegister i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableLessThanRegister()
		public JumpIfVariableLessThanRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableLessThanRegister copy()
		{
			return new JumpIfVariableLessThanRegister(this);
		}
	}

}