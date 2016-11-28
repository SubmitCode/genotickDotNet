using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class ZeroOutVariable : VarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -7513892893024990050L;
		private const long serialVersionUID = -7513892893024990050L;

		private ZeroOutVariable(ZeroOutVariable i)
		{
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public ZeroOutVariable()
		public ZeroOutVariable()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override ZeroOutVariable copy()
		{
			return new ZeroOutVariable(this);
		}

	}

}