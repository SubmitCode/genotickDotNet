using System;

namespace com.alphatica.genotick.data
{

	[Serializable]
	public class DataSetName
	{
		private const long serialVersionUID = -7504682119928833833L;
		private readonly string name;
		public DataSetName(string name)
		{
			this.name = name;
		}

		public override string ToString()
		{
			return name;
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}
			DataSetName that = (DataSetName) o;
			return name.Equals(that.name);
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}
	}

}