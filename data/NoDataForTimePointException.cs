using System;

namespace com.alphatica.genotick.data
{

	public class NoDataForTimePointException : Exception
	{
		internal static readonly NoDataForTimePointException instance = new NoDataForTimePointException();

	}

}