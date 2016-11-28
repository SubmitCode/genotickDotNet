using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MoveDoubleToRegister : RegDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8885197267150260362L;
		private const long serialVersionUID = -8885197267150260362L;

		private MoveDoubleToRegister(MoveDoubleToRegister i)
		{
			this.Register = i.Register;
			this.DoubleArgument = i.DoubleArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MoveDoubleToRegister()
		public MoveDoubleToRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MoveDoubleToRegister copy()
		{
			return new MoveDoubleToRegister(this);
		}

	}

}