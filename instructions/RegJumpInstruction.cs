using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class RegJumpInstruction : RegInstruction, JumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -4386895204308098944L;
		private const long serialVersionUID = -4386895204308098944L;

		private int address;

		internal RegJumpInstruction()
		{
			address = 0;
		}
		public virtual int Address
		{
			get
			{
				return address;
			}
			set
			{
				this.address = value;
			}
		}
		public override void mutate(Mutator mutator)
		{
			base.mutate(mutator);
			address = mutator.NextInt;
		}

	}

}