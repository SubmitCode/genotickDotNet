using System;

namespace com.alphatica.genotick.instructions
{


	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class AddDoubleToRegister : RegDoubleInstruction
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 2825034534810488187L;
		private const long serialVersionUID = 2825034534810488187L;

		private AddDoubleToRegister(AddDoubleToRegister i)
		{
			this.DoubleArgument = i.DoubleArgument;
			this.Register = i.Register;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public AddDoubleToRegister()
		public AddDoubleToRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override AddDoubleToRegister copy()
		{
			return new AddDoubleToRegister(this);
		}
	}

}