using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class DivideRegisterByDouble : RegDoubleInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 6495799568812947637L;
		private const long serialVersionUID = 6495799568812947637L;

		private DivideRegisterByDouble(DivideRegisterByDouble i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public DivideRegisterByDouble()
		public DivideRegisterByDouble()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override DivideRegisterByDouble copy()
		{
			return new DivideRegisterByDouble(this);
		}

	}

}