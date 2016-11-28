using System;

namespace com.alphatica.genotick.instructions
{

	using Processor = com.alphatica.genotick.processor.Processor;

	[Serializable]
	public class SubtractVariableFromRegister : RegVarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8639456508845181659L;
		private const long serialVersionUID = -8639456508845181659L;

		private SubtractVariableFromRegister(SubtractVariableFromRegister i)
		{
			this.Register = i.Register;
			this.VariableArgument = i.VariableArgument;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public SubtractVariableFromRegister()
		public SubtractVariableFromRegister()
		{
		}

		public override void executeOn(Processor processor)
		{
			processor.execute(this);
		}

		public override SubtractVariableFromRegister copy()
		{
			return new SubtractVariableFromRegister(this);
		}

	}

}