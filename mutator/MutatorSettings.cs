namespace com.alphatica.genotick.mutator
{

	public class MutatorSettings
	{
		private readonly double instructionMutationProbability;
		private readonly double newInstructionProbability;
		private readonly double skipInstructionProbability;

		public MutatorSettings(double instructionMutationProbability, double newInstructionProbability, double skipInstructionProbability)
		{
			this.instructionMutationProbability = instructionMutationProbability;
			this.newInstructionProbability = newInstructionProbability;
			this.skipInstructionProbability = skipInstructionProbability;
		}


		public virtual double InstructionMutationProbability
		{
			get
			{
				return instructionMutationProbability;
			}
		}

		public virtual double NewInstructionProbability
		{
			get
			{
				return newInstructionProbability;
			}
		}

		public virtual double SkipInstructionProbability
		{
			get
			{
				return skipInstructionProbability;
			}
		}

	}

}