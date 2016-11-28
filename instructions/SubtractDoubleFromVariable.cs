using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SubtractDoubleFromVariable : VarDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 8293191797685003121L;
		private const long serialVersionUID = 8293191797685003121L;

		private SubtractDoubleFromVariable(SubtractDoubleFromVariable i)
		{
			this.VariableArgument = i.VariableArgument;
			this.DoubleArgument = i.DoubleArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SubtractDoubleFromVariable()
		public SubtractDoubleFromVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SubtractDoubleFromVariable copy()
		{
			return new SubtractDoubleFromVariable(this);
		}

	}

}