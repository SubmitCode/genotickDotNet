using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	public abstract class RegRegInstruction : Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 6740011263492418256L;
		private const long serialVersionUID = 6740011263492418256L;

		private sbyte register1;
		private sbyte register2;

		public virtual sbyte Register1
		{
			get
			{
				return register1;
			}
			set
			{
				this.register1 = Registers.validateRegister(value);
			}
		}


		public virtual sbyte Register2
		{
			get
			{
				return register2;
			}
			set
			{
				this.register2 = Registers.validateRegister(value);
			}
		}


		public override void mutate(Mutator mutator)
		{
			sbyte value = Registers.validateRegister(mutator.NextByte);
			register1 = value;
			value = Registers.validateRegister(mutator.NextByte);
			register2 = value;
		}
	}

}