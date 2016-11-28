namespace com.alphatica.genotick.instructions
{

	internal class InstructionField
	{
		private readonly string name;
		private readonly string value;

		public InstructionField(string name, string value)
		{
			this.name = name;
			this.value = value;
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		public virtual string Value
		{
			get
			{
				return value;
			}
		}
	}

}