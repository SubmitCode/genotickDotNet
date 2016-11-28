using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MultiplyRegisterByDouble : RegDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 7017210446264669933L;
		private const long serialVersionUID = 7017210446264669933L;

		private MultiplyRegisterByDouble(MultiplyRegisterByDouble i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MultiplyRegisterByDouble()
		public MultiplyRegisterByDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MultiplyRegisterByDouble copy()
		{
			return new MultiplyRegisterByDouble(this);
		}

	}

}