using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SqRootOfRegister : RegRegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -2097327161652030023L;
		private const long serialVersionUID = -2097327161652030023L;

		private SqRootOfRegister(SqRootOfRegister i)
		{
			this.Register1 = i.Register1;
			this.Register2 = i.Register2;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SqRootOfRegister()
		public SqRootOfRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SqRootOfRegister copy()
		{
			return new SqRootOfRegister(this);
		}
	}

}