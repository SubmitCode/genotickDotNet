using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterNotEqualRegister : RegRegJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5597151246876888643L;
		private const long serialVersionUID = -5597151246876888643L;

		private JumpIfRegisterNotEqualRegister(JumpIfRegisterNotEqualRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterNotEqualRegister()
		public JumpIfRegisterNotEqualRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterNotEqualRegister copy()
		{
			return new JumpIfRegisterNotEqualRegister(this);
		}
	}

}