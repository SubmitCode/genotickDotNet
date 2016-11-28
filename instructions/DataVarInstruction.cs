using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class DataVarInstruction : DataInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -7780679428775612562L;
		private const long serialVersionUID = -7780679428775612562L;

		private int variableArgument;

		internal virtual int VariableArgument
		{
			set
			{
				this.variableArgument = value;
			}
			get
			{
				return variableArgument;
			}
		}

		public override void mutate(Mutator mutator)
		{
			base.mutate(mutator);
			variableArgument = mutator.NextInt;
		}

	}

}