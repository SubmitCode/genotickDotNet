using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveRegisterToVariable : RegVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -6846019505484559555L;
		private const long serialVersionUID = -6846019505484559555L;

		private MoveRegisterToVariable(MoveRegisterToVariable i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveRegisterToVariable()
		public MoveRegisterToVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveRegisterToVariable copy()
		{
			return new MoveRegisterToVariable(this);
		}

	}

}