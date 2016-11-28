using System;

namespace com.alphatica.genotick.instructions
{

	using NotEnoughDataException = com.alphatica.genotick.processor.NotEnoughDataException;
	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class DecrementVariable : VarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -3260981819622564798L;
		private const long serialVersionUID = -3260981819622564798L;

		private DecrementVariable(DecrementVariable i)
		{
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public DecrementVariable()
		public DecrementVariable()
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public void executeOn(com.alphatica.genotick.processor.Processor processor) throws com.alphatica.genotick.processor.NotEnoughDataException
		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override DecrementVariable copy()
		{
			return new DecrementVariable(this);
		}

	}

}