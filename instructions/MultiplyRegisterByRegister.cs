using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class MultiplyRegisterByRegister : RegRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 7185538925515388482L;
		private const long serialVersionUID = 7185538925515388482L;

		private MultiplyRegisterByRegister(MultiplyRegisterByRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public MultiplyRegisterByRegister()
		public MultiplyRegisterByRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override MultiplyRegisterByRegister copy()
		{
			return new MultiplyRegisterByRegister(this);
		}

	}

}