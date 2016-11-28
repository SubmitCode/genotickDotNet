using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterLessThanRegister : RegRegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 6368830686936614448L;
		private const long serialVersionUID = 6368830686936614448L;

		private JumpIfRegisterLessThanRegister(JumpIfRegisterLessThanRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterLessThanRegister()
		public JumpIfRegisterLessThanRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterLessThanRegister copy()
		{
			return new JumpIfRegisterLessThanRegister(this);
		}
	}

}