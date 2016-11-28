namespace com.alphatica.genotick.mutator
{

	public class MutatorFactory
	{
		public static Mutator getDefaultMutator(MutatorSettings mutatorSettings)
		{
			Mutator mutator = SimpleMutator.Instance;
			mutator.Settings = mutatorSettings;
			return mutator;
		}
	}

}