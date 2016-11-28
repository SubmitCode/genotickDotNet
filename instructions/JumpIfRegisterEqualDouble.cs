using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfRegisterEqualDouble : RegDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -3677241217620353564L;
		private const long serialVersionUID = -3677241217620353564L;

		private JumpIfRegisterEqualDouble(JumpIfRegisterEqualDouble i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.Register = i.Register;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfRegisterEqualDouble()
		public JumpIfRegisterEqualDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfRegisterEqualDouble copy()
		{
			return new JumpIfRegisterEqualDouble(this);
		}
	}

}