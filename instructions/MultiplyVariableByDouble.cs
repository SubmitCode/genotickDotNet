using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MultiplyVariableByDouble : VarDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -488671617233131162L;
		private const long serialVersionUID = -488671617233131162L;

		private MultiplyVariableByDouble(MultiplyVariableByDouble i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MultiplyVariableByDouble()
		public MultiplyVariableByDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MultiplyVariableByDouble copy()
		{
			return new MultiplyVariableByDouble(this);
		}

	}

}