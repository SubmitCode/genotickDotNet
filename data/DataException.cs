using System;

namespace com.alphatica.genotick.data
{

	internal class DataException : Exception
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5264726885012607329L;
		private const long serialVersionUID = -5264726885012607329L;

		public DataException(string s) : base(s)
		{
		}
	}

}