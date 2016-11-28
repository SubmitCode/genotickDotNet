namespace com.alphatica.genotick.mutator
{

	using Instruction = com.alphatica.genotick.instructions.Instruction;

	public interface Mutator
	{
		Instruction RandomInstruction {get;}

		bool AllowInstructionMutation {get;}

		bool AllowNewInstruction {get;}

		int NextInt {get;}

		double NextDouble {get;}

		sbyte NextByte {get;}

		MutatorSettings Settings {set;}

		bool skipNextInstruction();

	}

}