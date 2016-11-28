using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class ReturnVariableAsResult : VarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -1366004911226575165L;
		private const long serialVersionUID = -1366004911226575165L;

		private ReturnVariableAsResult(ReturnVariableAsResult i)
		{
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public ReturnVariableAsResult()
		public ReturnVariableAsResult()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override ReturnVariableAsResult copy()
		{
			return new ReturnVariableAsResult(this);
		}

	}

}