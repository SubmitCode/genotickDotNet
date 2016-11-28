using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class DecrementRegister : RegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -7630060970364313126L;
		private const long serialVersionUID = -7630060970364313126L;

		private DecrementRegister(DecrementRegister i)
		{
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public DecrementRegister()
		public DecrementRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override DecrementRegister copy()
		{
			return new DecrementRegister(this);
		}

	}

}