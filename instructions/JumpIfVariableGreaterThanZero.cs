using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableGreaterThanZero : VarJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -9053565445759017543L;
		private const long serialVersionUID = -9053565445759017543L;

		private JumpIfVariableGreaterThanZero(JumpIfVariableGreaterThanZero i)
		{
			this.VariableArgument = i.VariableArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableGreaterThanZero()
		public JumpIfVariableGreaterThanZero()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableGreaterThanZero copy()
		{
			return new JumpIfVariableGreaterThanZero(this);
		}
	}

}