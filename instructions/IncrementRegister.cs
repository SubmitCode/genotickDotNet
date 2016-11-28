using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class IncrementRegister : RegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3654031193344071193L;
		private const long serialVersionUID = 3654031193344071193L;

		private IncrementRegister(IncrementRegister i)
		{
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public IncrementRegister()
		public IncrementRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override IncrementRegister copy()
		{
			return new IncrementRegister(this);
		}

	}

}