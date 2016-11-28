using System;
using System.Collections.Generic;
using System.Text;

namespace com.alphatica.genotick.reversal
{

	using DataSet = com.alphatica.genotick.data.DataSet;
	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using FileSystemDataLoader = com.alphatica.genotick.data.FileSystemDataLoader;
	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	public class Reversal
	{
		private readonly string reverseValue;
		private readonly UserOutput output;

		public Reversal(string reverseValue, UserOutput output)
		{
			this.reverseValue = reverseValue;
			this.output = output;
		}

		public virtual void reverse()
		{
			FileSystemDataLoader loader = new FileSystemDataLoader(reverseValue);
			MainAppData data = loader.createRobotData(output);
			reverseData(data);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public static com.alphatica.genotick.data.MainAppData reverse(com.alphatica.genotick.data.MainAppData data)
		public static MainAppData reverse(MainAppData data)
		{
			MainAppData reversedData = new MainAppData();
			foreach (DataSet set in data.listSets())
			{
				IList<Number []> originalNumbers = getOriginalNumbers(set);
				IList<Number []> reversedNumbers = reverseList(originalNumbers);
				string reverseName = getReverseFileName(set.Name);
				DataSet reversedSet = new DataSet(reversedNumbers,reverseName);
				reversedData.addDataSet(reversedSet);
			}
			return reversedData;
		}
		private void reverseData(MainAppData data)
		{
			data.listSets().forEach(this.reverseSet);
		}

		private void reverseSet(DataSet set)
		{
			string reverseFileName = getReverseFileName(set.Name);
			File reverseFile = new File(reverseFileName);
			if (reverseFile.exists())
			{
				output.warningMessage("File " + reverseFileName + " already exists. Not reversing " + set.Name);
				return;
			}
			IList<Number[]> original = getOriginalNumbers(set);
			IList<Number[]> reverse = reverseList(original);
			writeReverseToFile(reverse, reverseFileName);
		}

		private static string getReverseFileName(DataSetName name)
		{
			Path full = Paths.get(name.Name);
			Path parent = full.Parent;
			string newName = "reverse_" + full.FileName.ToString();
			return Paths.get(parent.ToString(), newName).ToString();
		}

		private static IList<Number[]> reverseList(IList<Number[]> original)
		{
			IList<Number []> reverse = new List<Number []>();
			Number[] lastOriginal = null;
			Number[] lastReversed = null;
			foreach (Number[] table in original)
			{
				Number[] last = reverseLineOHLCV(table, lastOriginal, lastReversed);
				reverse.Add(last);
				lastOriginal = table;
				lastReversed = last;
			}
			return reverse;
		}

		/*
		 * This method is for reversing traditional open-high-low-close stock market data.
		 * What happens with numbers (by column):
		 * 0 - TimePoint: Doesn't change.
		 * 1 - Open: It goes opposite direction to original, by the same percent.
		 * 2 and 3 - High and Low: First of all they swapped. This is because data should be a mirror reflection of
		 * original, so high becomes low and low becomes high. Change is calculated comparing to open column
		 * (column 1). So it doesn't matter what High was in previous TimePoint, it matters how much higher it was comparing
		 * to the open on the same line. When High becomes low - it goes down by same percent as original high was higher
		 * than open.
		 * 4 - Close. Goes opposite to original close by the same percent.
		 * 5 and more - Volume, open interest or whatever. These don't change.
		 */

		private static Number[] reverseLineOHLCV(Number[] table, Number[] lastOriginal, Number[] lastReversed)
		{
			Number[] reversed = new Number[table.Length];
			// Column 0 is unchanged
			reversed[0] = table[0];
			// Column 1. Rewrite if first line
			if (lastOriginal == null)
			{
				reversed[1] = table[1];
			}
			else
			{
				// Change by % if not first line
				reversed[1] = getReverseValue(table[1],lastOriginal[1],lastReversed[1]);
			}
			// Check if 4 columns here, because we need time, open, high, low to do swapping later.
			if (table.Length < 4)
			{
				return reversed;
			}
			// Column 2. Change by % comparing to open
			// Write into 3 - we swap 2 & 3
			reversed[3] = getReverseValue(table[2], table[1], reversed[1]);
			// Column 3. Change by % comparing to open
			// Write into 2 - we swap 2 & 3
			reversed[2] = getReverseValue(table[3],table[1],reversed[1]);
			if (table.Length == 4)
			{
				return reversed;
			}
			// Column 4. Change by % comparing to open.
			reversed[4] = getReverseValue(table[4],table[1],reversed[1]);
			// Rewrite rest
			Array.Copy(table, 5, reversed, 5, table.Length - 5);
			return reversed;
		}

		private static Number getReverseValue(Number from, Number to, Number compare)
		{
			double diff = Math.Abs((from.doubleValue() / to.doubleValue()) - 2);
			return diff * compare.doubleValue();
		}

		private void writeReverseToFile(IList<Number[]> reverse, string reversedFileName)
		{
			try
			{
					using (System.IO.StreamWriter bw = new System.IO.StreamWriter(reversedFileName))
					{
					foreach (Number[] table in reverse)
					{
						string row = mkString(table,",");
						bw.write(row + "\n");
					}
					}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: private String mkString(Number[] table, @SuppressWarnings("SameParameterValue") String string)
		private string mkString(Number[] table, ("SameParameterValue") string @string)
		{
			StringBuilder sb = new StringBuilder();
			int count = 0;
			foreach (Number number in table)
			{
				sb.Append(number);
				count++;
				if (count < table.Length)
				{
					sb.Append(@string);
				}
			}
			return sb.ToString();
		}

		private static IList<Number[]> getOriginalNumbers(DataSet set)
		{
			IList<Number[]> list = new List<Number[]>();
			for (int i = 0; i < set.LinesCount; i++)
			{
				list.Add(set.getLine(i));
			}
			return list;
		}
	}

}