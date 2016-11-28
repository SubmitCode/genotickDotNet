using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SubtractDoubleFromRegister : RegDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 8867925324160720308L;
		private const long serialVersionUID = 8867925324160720308L;

		private SubtractDoubleFromRegister(SubtractDoubleFromRegister i)
		{
			this.Register = i.Register;
			this.DoubleArgument = i.DoubleArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SubtractDoubleFromRegister()
		public SubtractDoubleFromRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SubtractDoubleFromRegister copy()
		{
			return new SubtractDoubleFromRegister(this);
		}
	}

}