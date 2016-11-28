using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	public abstract class DataRegInstruction : DataInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 4226724935141470072L;
		private const long serialVersionUID = 4226724935141470072L;

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
			base.mutate(mutator);
			register = Registers.validateRegister(mutator.NextByte);
		}
	}

}