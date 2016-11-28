using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SumOfColumn : RegRegInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -4448791341243829694L;
		private const long serialVersionUID = -4448791341243829694L;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SumOfColumn()
		public SumOfColumn()
		{
		}

		private SumOfColumn(SumOfColumn ins)
		{
			this.Register1 = ins.Register1;
			this.Register2 = ins.Register2;
		}
		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override Instruction copy()
		{
			return new SumOfColumn(this);
		}
	}

}