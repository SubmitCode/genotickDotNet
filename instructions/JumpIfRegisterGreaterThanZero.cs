using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterGreaterThanZero : RegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 2932427307222806723L;
		private const long serialVersionUID = 2932427307222806723L;

		private JumpIfRegisterGreaterThanZero(JumpIfRegisterGreaterThanZero i)
		{
			this.Register = i.Register;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterGreaterThanZero()
		public JumpIfRegisterGreaterThanZero()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterGreaterThanZero copy()
		{
			return new JumpIfRegisterGreaterThanZero(this);
		}
	}

}