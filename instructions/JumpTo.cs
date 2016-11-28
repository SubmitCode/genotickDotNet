using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;
	using NotEnoughDataException = com.alphatica.genotick.processor.NotEnoughDataException;
	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class JumpTo : Instruction, JumpInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 8996188434274451095L;
		private const long serialVersionUID = 8996188434274451095L;

		private int address;

		private JumpTo(JumpTo i)
		{
			this.address = i.Address;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public JumpTo()
		public JumpTo()
		{
			address = 0;
		}
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public void executeOn(com.alphatica.genotick.processor.Processor processor) throws com.alphatica.genotick.processor.NotEnoughDataException
		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override void mutate(Mutator mutator)
		{
			address = mutator.NextInt;
		}

		public override JumpTo copy()
		{
			return new JumpTo(this);
		}

		public virtual int Address
		{
			get
			{
				return address;
			}
		}
	}

}