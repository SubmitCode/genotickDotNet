using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class VarInstruction : Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5052271226112971349L;
		private const long serialVersionUID = 5052271226112971349L;

		private int variableArgument;

		public virtual int VariableArgument
		{
			get
			{
				return variableArgument;
			}
			set
			{
				this.variableArgument = value;
			}
		}


		public override void mutate(Mutator mutator)
		{
			variableArgument = mutator.NextInt;
		}
	}

}