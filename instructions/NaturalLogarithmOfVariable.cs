using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class NaturalLogarithmOfVariable : VarVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -3112125542251877233L;
		private const long serialVersionUID = -3112125542251877233L;

		private NaturalLogarithmOfVariable(NaturalLogarithmOfVariable i)
		{
			this.Variable1Argument = i.Variable1Argument;
			this.Variable2Argument = i.Variable2Argument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public NaturalLogarithmOfVariable()
		public NaturalLogarithmOfVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override NaturalLogarithmOfVariable copy()
		{
			return new NaturalLogarithmOfVariable(this);
		}
	}

}