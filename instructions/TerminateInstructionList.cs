using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;
	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class TerminateInstructionList : Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5432002295875235819L;
		private const long serialVersionUID = 5432002295875235819L;

		public TerminateInstructionList()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}


		public override void mutate(Mutator mutator)
		{
			/*
			Empty. Nothing to mutate.
			 */
		}

		public override Instruction copy()
		{
			return new TerminateInstructionList();
		}
	}

}