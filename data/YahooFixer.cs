using System.Collections.Generic;
using System.Text;

namespace com.alphatica.genotick.data
{

	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	public class YahooFixer
	{
		private readonly string path;

		public YahooFixer(string yahooValue)
		{
			this.path = yahooValue;
		}

		public virtual void fixFiles(UserOutput output)
		{
			string extension = ".csv";
			IList<string> names = DataUtils.listFiles(extension,path);
			foreach (string name in names)
			{
				fixFile(name,output);
			}
		}

		private void fixFile(string name, UserOutput output)
		{
			output.infoMessage("Fixing file: " + name);
			IList<Number[]> originalList = buildOriginalList(name);
			originalList.Reverse();
			IList<IList<Number>> newList = fixList(originalList);
			saveListToFile(newList,name);
		}

		private void saveListToFile(IList<IList<Number>> newList, string name)
		{
			try
			{
					using (System.IO.StreamWriter bw = new System.IO.StreamWriter(new File(name)))
					{
					writeList(newList,bw);
					}
			}
			catch (IOException e)
			{
				DataException dataException = new DataException("Unable to write file " + name);
				dataException.initCause(e);
				throw dataException;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void writeList(java.util.List<java.util.List<Number>> newList, BufferedWriter bw) throws IOException
		private void writeList(IList<IList<Number>> newList, System.IO.StreamWriter bw)
		{
			foreach (IList<Number> line in newList)
			{
				writeLine(line,bw);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void writeLine(java.util.List<Number> line, BufferedWriter bw) throws IOException
		private void writeLine(IList<Number> line, System.IO.StreamWriter bw)
		{
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator<Number> iterator = line.GetEnumerator();
			while (iterator.MoveNext())
			{
				Number number = iterator.Current;
				stringBuilder.Append(number.ToString());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
				if (iterator.hasNext())
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("\n");
			bw.append(stringBuilder.ToString());
		}

		private IList<IList<Number>> fixList(IList<Number[]> originalList)
		{
			IList<IList<Number>> newList = new List<IList<Number>>(originalList.Count);
			foreach (Number[] line in originalList)
			{
				IList<Number> fixedLine = fixLine(line);
				newList.Add(fixedLine);
			}
			return newList;
		}

		private IList<Number []> buildOriginalList(string name)
		{
			try
			{
					using (System.IO.StreamReader br = new System.IO.StreamReader(new File(name)))
					{
					ignoreFirstLine(br);
					return DataUtils.createLineList(br);
					}
			}
			catch (IOException e)
			{
				DataException dataException = new DataException("Unable to read file " + name);
				dataException.initCause(e);
				throw dataException;
			}
		}

		/*
		This is how it works:
		0th number is time - so it's unchanged
		1st number is open: calculate difference from open to close. Use adjusted close (number at index 6)
		    to calculate new value.
		The same for numbers 2 and 3.
		4th number - replace with adjusted close
		5th number - volume. Recalcute according to adjusted close
		 */
		private IList<Number> fixLine(Number[] line)
		{
			IList<Number> newLine = new List<Number>(line.Length);
			double originalClose = line[4].doubleValue();
			double adjustedClose = line[6].doubleValue();
			// Nothing with to do be done with Date
			newLine.Add(line[0]);
			double open = calculateNew(line[1],originalClose,adjustedClose);
			newLine.Add(open);
			double high = calculateNew(line[2],originalClose,adjustedClose);
			newLine.Add(high);
			double low = calculateNew(line[3],originalClose,adjustedClose);
			newLine.Add(low);
			// add adjusted close as 'close'
			newLine.Add(adjustedClose);
			// recalcute volume
			double volumeValue = originalClose * line[5].doubleValue();
			double volumeCount = volumeValue / adjustedClose;
			newLine.Add(volumeCount);
			return newLine;
		}

		private double calculateNew(Number number, double originalClose, double adjustedClose)
		{
			double change = number.doubleValue() / originalClose;
			return adjustedClose * change;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void ignoreFirstLine(BufferedReader br) throws IOException
		private void ignoreFirstLine(System.IO.StreamReader br)
		{
			br.ReadLine();
		}

	}

}