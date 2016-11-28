using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpIfVariableLessThanDouble : VarDoubleJumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8449905052813057724L;
		private const long serialVersionUID = -8449905052813057724L;

		private JumpIfVariableLessThanDouble(JumpIfVariableLessThanDouble i)
		{
			this.VariableArgument = i.VariableArgument;
			this.DoubleArgument = i.DoubleArgument;
			this.Address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpIfVariableLessThanDouble()
		public JumpIfVariableLessThanDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override JumpIfVariableLessThanDouble copy()
		{
			return new JumpIfVariableLessThanDouble(this);
		}
	}

}