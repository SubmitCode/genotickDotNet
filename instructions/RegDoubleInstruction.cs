using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	internal abstract class RegDoubleInstruction : RegInstruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -8574875071910464339L;
		private const long serialVersionUID = -8574875071910464339L;

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