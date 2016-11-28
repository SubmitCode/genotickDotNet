using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class NaturalLogarithmOfRegister : RegRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5965927479237202603L;
		private const long serialVersionUID = -5965927479237202603L;

		private NaturalLogarithmOfRegister(NaturalLogarithmOfRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public NaturalLogarithmOfRegister()
		public NaturalLogarithmOfRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override NaturalLogarithmOfRegister copy()
		{
			return new NaturalLogarithmOfRegister(this);
		}
	}

}