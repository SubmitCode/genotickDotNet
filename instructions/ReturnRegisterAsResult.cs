using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class ReturnRegisterAsResult : RegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -884883538461289844L;
		private const long serialVersionUID = -884883538461289844L;

		private ReturnRegisterAsResult(ReturnRegisterAsResult i)
		{
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public ReturnRegisterAsResult()
		public ReturnRegisterAsResult()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override ReturnRegisterAsResult copy()
		{
			return new ReturnRegisterAsResult(this);
		}

	}

}