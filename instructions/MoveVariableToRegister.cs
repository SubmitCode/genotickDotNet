using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveVariableToRegister : RegVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -3943721532302613198L;
		private const long serialVersionUID = -3943721532302613198L;

		private MoveVariableToRegister(MoveVariableToRegister i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveVariableToRegister()
		public MoveVariableToRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveVariableToRegister copy()
		{
			return new MoveVariableToRegister(this);
		}

	}

}