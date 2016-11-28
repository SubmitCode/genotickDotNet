using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SubtractRegisterFromVariable : RegVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -2540080410599300603L;
		private const long serialVersionUID = -2540080410599300603L;

		private SubtractRegisterFromVariable(SubtractRegisterFromVariable i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SubtractRegisterFromVariable()
		public SubtractRegisterFromVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SubtractRegisterFromVariable copy()
		{
			return new SubtractRegisterFromVariable(this);
		}
	}

}