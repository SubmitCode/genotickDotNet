using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableGreaterThanDouble : VarDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 2980935422934405842L;
		private const long serialVersionUID = 2980935422934405842L;

		private JumpIfVariableGreaterThanDouble(JumpIfVariableGreaterThanDouble i)
		{
			this.VariableArgument = i.VariableArgument;
			this.DoubleArgument = i.DoubleArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableGreaterThanDouble()
		public JumpIfVariableGreaterThanDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableGreaterThanDouble copy()
		{
			return new JumpIfVariableGreaterThanDouble(this);
		}
	}

}