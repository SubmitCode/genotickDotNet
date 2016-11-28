using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterGreaterThanDouble : RegDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3245923977507621290L;
		private const long serialVersionUID = 3245923977507621290L;

		private JumpIfRegisterGreaterThanDouble(JumpIfRegisterGreaterThanDouble i)
		{
			this.Address = i.Address;
			this.DoubleArgument = i.DoubleArgument;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterGreaterThanDouble()
		public JumpIfRegisterGreaterThanDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterGreaterThanDouble copy()
		{
			return new JumpIfRegisterGreaterThanDouble(this);
		}
	}

}