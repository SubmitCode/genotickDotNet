using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterNotEqualZero : RegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -6429106660478254250L;
		private const long serialVersionUID = -6429106660478254250L;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterNotEqualZero()
		public JumpIfRegisterNotEqualZero()
		{
		}

		private JumpIfRegisterNotEqualZero(JumpIfRegisterNotEqualZero i)
		{
			this.Register = i.Register;
			this.Address = i.Address;
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterNotEqualZero copy()
		{
			return new JumpIfRegisterNotEqualZero(this);
		}
	}
}