using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SubtractRegisterFromRegister : RegRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5487441136619310076L;
		private const long serialVersionUID = -5487441136619310076L;

		private SubtractRegisterFromRegister(SubtractRegisterFromRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SubtractRegisterFromRegister()
		public SubtractRegisterFromRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SubtractRegisterFromRegister copy()
		{
			return new SubtractRegisterFromRegister(this);
		}

	}

}