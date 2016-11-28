using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class DivideRegisterByRegister : RegRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5202607381101727036L;
		private const long serialVersionUID = 5202607381101727036L;

		private DivideRegisterByRegister(DivideRegisterByRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public DivideRegisterByRegister()
		public DivideRegisterByRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override DivideRegisterByRegister copy()
		{
			return new DivideRegisterByRegister(this);
		}

	}

}