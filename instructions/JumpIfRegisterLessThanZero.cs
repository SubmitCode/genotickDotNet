using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterLessThanZero : RegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5576287341828522397L;
		private const long serialVersionUID = 5576287341828522397L;

		private JumpIfRegisterLessThanZero(JumpIfRegisterLessThanZero i)
		{
			this.Register = i.Register;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterLessThanZero()
		public JumpIfRegisterLessThanZero()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterLessThanZero copy()
		{
			return new JumpIfRegisterLessThanZero(this);
		}
	}

}