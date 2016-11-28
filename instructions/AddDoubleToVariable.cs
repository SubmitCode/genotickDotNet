using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class AddDoubleToVariable : VarDoubleInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -6197886980513050186L;
		private const long serialVersionUID = -6197886980513050186L;

		private AddDoubleToVariable(AddDoubleToVariable i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public AddDoubleToVariable()
		public AddDoubleToVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override AddDoubleToVariable copy()
		{
			return new AddDoubleToVariable(this);
		}

	}

}