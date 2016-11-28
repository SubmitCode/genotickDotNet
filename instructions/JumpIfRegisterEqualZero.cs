using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterEqualZero : RegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5735491554481943162L;
		private const long serialVersionUID = 5735491554481943162L;

		private JumpIfRegisterEqualZero(JumpIfRegisterEqualZero i)
		{
			this.Register = i.Register;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterEqualZero()
		public JumpIfRegisterEqualZero()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterEqualZero copy()
		{
			return new JumpIfRegisterEqualZero(this);
		}
	}

}