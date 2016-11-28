using System;

namespace com.alphatica.genotick.ui
{

	public class UserInputOutputFactory
	{
		private const string INPUT_STRING = "input";
		private const string OUTPUT_STRING = "output";

		public static UserInput getUserInput(Parameters parameters)
		{
			string input = parameters.getValue(INPUT_STRING);
			parameters.removeKey(INPUT_STRING);
			if (string.ReferenceEquals(input, null))
			{
				return tryConsoleInput();
			}
			if (input.StartsWith("file" + FileInput.delimiter, StringComparison.Ordinal))
			{
				return new FileInput(input);
			}
			switch (input)
			{
				case "default":
					return new DefaultInputs();
				case "random":
					return new RandomParametersInput();
				case "console":
					return tryConsoleInput();
			}
			return null;
		}

		private static UserInput tryConsoleInput()
		{
			UserInput input;
			try
			{
				input = new ConsoleInput();
				return input;
			}
			catch (Exception)
			{
				Console.Error.WriteLine("Unable to get Console Input. Resorting to Default Input");
				return new DefaultInputs();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static UserOutput getUserOutput(Parameters parameters) throws java.io.IOException
		public static UserOutput getUserOutput(Parameters parameters)
		{
			string output = parameters.getValue(OUTPUT_STRING);
			parameters.removeKey(OUTPUT_STRING);
			if (!string.ReferenceEquals(output, null) && output.Equals("csv"))
			{
				return new CsvOutput();
			}
			else
			{
				return new ConsoleOutput();
			}

		}
	}

}