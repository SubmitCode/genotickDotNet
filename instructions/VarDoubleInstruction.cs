using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class VarDoubleInstruction : VarInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 5798418310767182684L;
		private const long serialVersionUID = 5798418310767182684L;

		private double doubleArgument;

		internal virtual double DoubleArgument
		{
			set
			{
				this.doubleArgument = value;
			}
			get
			{
				return doubleArgument;
			}
		}


		public override void mutate(Mutator mutator)
		{
			base.mutate(mutator);
			doubleArgument = Tools.mutateDouble(doubleArgument, mutator);
		}

	}

}