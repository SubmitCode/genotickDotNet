using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class HighestOfColumn : RegRegInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -7922049215420858405L;
		private const long serialVersionUID = -7922049215420858405L;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public HighestOfColumn()
		public HighestOfColumn()
		{

		}

		private HighestOfColumn(HighestOfColumn highestOfColumn)
		{
			this.Register1 = highestOfColumn.Register1;
			this.Register2 = highestOfColumn.Register2;
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override Instruction copy()
		{
			return new HighestOfColumn(this);
		}
	}

}