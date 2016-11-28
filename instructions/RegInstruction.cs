using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class RegInstruction : Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5825464773734754580L;
		private const long serialVersionUID = -5825464773734754580L;

		private sbyte register;

		public virtual sbyte Register
		{
			get
			{
				return register;
			}
			set
			{
				this.register = Registers.validateRegister(value);
			}
		}


		public override void mutate(Mutator mutator)
		{
			register = Registers.validateRegister(mutator.NextByte);

		}
	}

}