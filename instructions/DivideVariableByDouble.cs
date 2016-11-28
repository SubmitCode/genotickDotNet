using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class DivideVariableByDouble : VarDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 2277032167143213475L;
		private const long serialVersionUID = 2277032167143213475L;

		private DivideVariableByDouble(DivideVariableByDouble i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public DivideVariableByDouble()
		public DivideVariableByDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override DivideVariableByDouble copy()
		{
			return new DivideVariableByDouble(this);
		}

	}

}