using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class ZeroOutRegister : RegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 7925325642053814475L;
		private const long serialVersionUID = 7925325642053814475L;

		private ZeroOutRegister(ZeroOutRegister i)
		{
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public ZeroOutRegister()
		public ZeroOutRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override ZeroOutRegister copy()
		{
			return new ZeroOutRegister(this);
		}
	}

}