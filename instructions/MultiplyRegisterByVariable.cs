using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MultiplyRegisterByVariable : RegVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5195803067958383416L;
		private const long serialVersionUID = 5195803067958383416L;

		private MultiplyRegisterByVariable(MultiplyRegisterByVariable i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MultiplyRegisterByVariable()
		public MultiplyRegisterByVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MultiplyRegisterByVariable copy()
		{
			return new MultiplyRegisterByVariable(this);
		}

	}

}