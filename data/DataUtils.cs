using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.data
{


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("WeakerAccess") public class DataUtils
	public class DataUtils
	{

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public static List<String> listFiles(final String extension, final String... paths)
		public static IList<string> listFiles(string extension, params string[] paths)
		{
			IList<string> list = new List<string>();
			foreach (string path in paths)
			{
				((List<string>)list).AddRange(namesFromPath(path,extension));
			}
			return list;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: private static List<String> namesFromPath(String path, final String extension)
		private static IList<string> namesFromPath(string path, string extension)
		{
			IList<string> list = new List<string>();
			File file = new File(path);
			if (file.Directory)
			{
				((List<string>)list).AddRange(getFullPaths(path,extension));
			}
			else
			{
				list.Add(path);
			}
			return list;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: private static List<String> getFullPaths(String path, final String extension)
		private static IList<string> getFullPaths(string path, string extension)
		{
			File file = new File(path);
			string[] names = file.list((file1, name) => name.EndsWith(extension));
			IList<string> list = new List<string>();
			foreach (string name in names)
			{
				list.Add(path + File.separator + name);
			}
			return list;
		}

		public static IList<Number []> createLineList(System.IO.StreamReader br)
		{
			IList<Number []> list = new List<Number []>();
			int linesRead = 1;
			try
			{
				buildLines(br, list);
				return list;
			}
			catch (System.Exception ex) when (ex is IOException || ex is System.FormatException || ex is System.IndexOutOfRangeException)
			{
				DataException de = new DataException("Error reading line " + linesRead);
				de.initCause(ex);
				throw de;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private static void buildLines(java.io.BufferedReader br, List<Number[]> list) throws java.io.IOException
		private static void buildLines(System.IO.StreamReader br, IList<Number[]> list)
		{
			string line;
			line = br.ReadLine();
			processFirstLine(line,list);
			while (!string.ReferenceEquals((line = br.ReadLine()), null))
			{
				Number[] row = processLine(line);
				list.Add(row);
			}
		}

		private static void processFirstLine(string line, IList<Number[]> list)
		{
			try
			{
				Number[] row = processLine(line);
				list.Add(row);
			}
			catch (System.FormatException)
			{
				/* If it's the first line then it's probably just a heading. Let's ignore NFE */
			}
		}


		public static Number[] processLine(string line)
		{
			string separator = ",";
			string[] fields = line.Split(separator, true);
			Number[] array = new Number[fields.Length];
			string timePointString = getTimePointString(fields[0]);
			array[0] = Convert.ToInt64(timePointString);
			for (int i = 1; i < fields.Length; i++)
			{
				array[i] = Convert.ToDouble(fields[i]);
			}
			return array;
		}

		public static string getTimePointString(string field)
		{
			if (field.Contains("-"))
			{
				return field.replaceAll("-","");
			}
			else
			{
				return field;
			}

		}

		public static string DateTimeString
		{
			get
			{
				DateFormat format = new SimpleDateFormat("yyyy_MM_dd_HH_mm");
				return format.format(new DateTime());
			}
		}
	}

}