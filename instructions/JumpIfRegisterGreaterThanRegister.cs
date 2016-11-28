using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterGreaterThanRegister : RegRegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -7544201771600408606L;
		private const long serialVersionUID = -7544201771600408606L;

		private JumpIfRegisterGreaterThanRegister(JumpIfRegisterGreaterThanRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterGreaterThanRegister()
		public JumpIfRegisterGreaterThanRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterGreaterThanRegister copy()
		{
			return new JumpIfRegisterGreaterThanRegister(this);
		}
	}

}