using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterLessThanDouble : RegDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8871392325622765389L;
		private const long serialVersionUID = -8871392325622765389L;

		private JumpIfRegisterLessThanDouble(JumpIfRegisterLessThanDouble i)
		{
			this.Register = i.Register;
			this.DoubleArgument = i.DoubleArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterLessThanDouble()
		public JumpIfRegisterLessThanDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterLessThanDouble copy()
		{
			return new JumpIfRegisterLessThanDouble(this);
		}
	}

}