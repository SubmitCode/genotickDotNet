using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableGreaterThanRegister : RegVarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5018149141040073118L;
		private const long serialVersionUID = 5018149141040073118L;

		private JumpIfVariableGreaterThanRegister(JumpIfVariableGreaterThanRegister i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableGreaterThanRegister()
		public JumpIfVariableGreaterThanRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableGreaterThanRegister copy()
		{
			return new JumpIfVariableGreaterThanRegister(this);
		}
	}

}