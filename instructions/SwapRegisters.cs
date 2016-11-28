using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SwapRegisters : RegRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -3433775138789900573L;
		private const long serialVersionUID = -3433775138789900573L;

		private SwapRegisters(SwapRegisters i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SwapRegisters()
		public SwapRegisters()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SwapRegisters copy()
		{
			return new SwapRegisters(this);
		}
	}

}