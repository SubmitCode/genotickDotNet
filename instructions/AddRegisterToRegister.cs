using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class AddRegisterToRegister : RegRegInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 3465536183323672440L;
		private const long serialVersionUID = 3465536183323672440L;

		private AddRegisterToRegister(AddRegisterToRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public AddRegisterToRegister()
		public AddRegisterToRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override AddRegisterToRegister copy()
		{
			return new AddRegisterToRegister(this);
		}

	}

}