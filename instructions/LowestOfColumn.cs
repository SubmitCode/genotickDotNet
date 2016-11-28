using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class LowestOfColumn : RegRegInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -6945803435707758563L;
		private const long serialVersionUID = -6945803435707758563L;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public LowestOfColumn()
		public LowestOfColumn()
		{
		}

		private LowestOfColumn(LowestOfColumn lowestOfColumn)
		{
			this.Register1 = lowestOfColumn.Register1;
			this.Register2 = lowestOfColumn.Register2;
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override Instruction copy()
		{
			return new LowestOfColumn(this);
		}
	}

}