using System;

namespace com.alphatica.genotick.population
{

	internal class DAOException : Exception
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -5112797895442527318L;
		private const long serialVersionUID = -5112797895442527318L;

		public DAOException(Exception e) : base(e)
		{
		}

		public DAOException(string s) : base(s)
		{
		}
	}

}