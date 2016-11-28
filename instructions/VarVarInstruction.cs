using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class VarVarInstruction : Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8461921520321026497L;
		private const long serialVersionUID = -8461921520321026497L;

		private int variable1Argument;
		private int variable2Argument;

		public virtual int Variable1Argument
		{
			get
			{
				return variable1Argument;
			}
			set
			{
				this.variable1Argument = value;
			}
		}


		public virtual int Variable2Argument
		{
			get
			{
				return variable2Argument;
			}
			set
			{
				this.variable2Argument = value;
			}
		}


		public override void mutate(Mutator mutator)
		{
			variable1Argument = mutator.NextInt;
			variable2Argument = mutator.NextInt;
		}
	}

}