using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class AverageOfColumn : RegRegInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -329518949586814597L;
		private const long serialVersionUID = -329518949586814597L;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public AverageOfColumn()
		public AverageOfColumn()
		{
		}

		private AverageOfColumn(AverageOfColumn averageOfColumn)
		{
			this.Register1 = averageOfColumn.Register1;
			this.Register2 = averageOfColumn.Register2;
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override Instruction copy()
		{
			return new AverageOfColumn(this);
		}
	}

}