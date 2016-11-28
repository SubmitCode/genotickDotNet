using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SwapVariables : VarVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -6328103475159894381L;
		private const long serialVersionUID = -6328103475159894381L;

		private SwapVariables(SwapVariables i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SwapVariables()
		public SwapVariables()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SwapVariables copy()
		{
			return new SwapVariables(this);
		}

	}

}