using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterNotEqualDouble : RegDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8395514990644799759L;
		private const long serialVersionUID = -8395514990644799759L;

		private JumpIfRegisterNotEqualDouble(JumpIfRegisterNotEqualDouble i)
		{
			this.Register = i.Register;
			this.DoubleArgument = i.DoubleArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterNotEqualDouble()
		public JumpIfRegisterNotEqualDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterNotEqualDouble copy()
		{
			return new JumpIfRegisterNotEqualDouble(this);
		}
	}

}