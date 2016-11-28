using System;

namespace com.alphatica.genotick.population
{

	[Serializable]
	public class RobotName
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private final static long serialVersionUID = 32136468798664L;
		private const long serialVersionUID = 32136468798664L;
		private readonly long name;

		public RobotName(long name)
		{
			this.name = name;
		}

		public virtual long Name
		{
			get
			{
				return name;
			}
		}

		public override string ToString()
		{
			return name.ToString();
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
			RobotName that = (RobotName) o;
			return name == that.Name;
		}

		public override int GetHashCode()
		{
			return (int)(name ^ ((long)((ulong)name >> 32)));
		}
	}

}