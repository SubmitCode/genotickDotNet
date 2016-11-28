using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SqRootOfVariable : VarVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -6025395017177611705L;
		private const long serialVersionUID = -6025395017177611705L;

		private SqRootOfVariable(SqRootOfVariable i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SqRootOfVariable()
		public SqRootOfVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SqRootOfVariable copy()
		{
			return new SqRootOfVariable(this);
		}
	}

}