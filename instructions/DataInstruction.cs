using System;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	[Serializable]
	public abstract class DataInstruction : Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -2955270878126863352L;
		private const long serialVersionUID = -2955270878126863352L;
		private int dataTableIndex;
		private int dataOffsetIndex;

		internal virtual int DataTableIndex
		{
			set
			{
				this.dataTableIndex = value;
			}
		}

		internal virtual int DataOffsetIndex
		{
			set
			{
				this.dataOffsetIndex = value;
			}
			get
			{
				return dataOffsetIndex;
			}
		}

		public virtual int DataColumnIndex
		{
			get
			{
				return dataTableIndex;
			}
		}


		public override void mutate(Mutator mutator)
		{
			dataTableIndex = mutator.NextInt;
			dataOffsetIndex = mutator.NextInt;
		}
	}

}