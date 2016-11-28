using System.Threading;

namespace com.alphatica.genotick.ui
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using Prediction = com.alphatica.genotick.genotick.Prediction;
	using Tools = com.alphatica.genotick.genotick.Tools;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;


	public class CsvOutput : UserOutput
	{
		private readonly ConsoleOutput console;
		private readonly SimpleTextWriter profitWriter;
		private readonly SimpleTextWriter predictionWriter;
		private readonly string pidString;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public CsvOutput() throws java.io.IOException
		public CsvOutput()
		{
			console = new ConsoleOutput();
			pidString = Tools.PidString;
			profitWriter = new SimpleTextWriter("profit_" + pidString + ".csv");
			predictionWriter = new SimpleTextWriter("predictions_" + pidString + ".csv");
		}

		public virtual void errorMessage(string message)
		{
			console.errorMessage(message);
		}

		public virtual void warningMessage(string message)
		{
			console.warningMessage(message);
		}

		public virtual void reportProfitForTimePoint(TimePoint timePoint, double cumulativeProfit, double timePointProfit)
		{
			string line = timePoint.ToString() + "," + cumulativeProfit.ToString() + "," + timePointProfit.ToString();
			profitWriter.writeLine(line);
		}

		public virtual void showPrediction(TimePoint timePoint, DataSetName name, Prediction prediction)
		{
			string line = string.Format("{0},{1},{2}",timePoint.ToString(),name.ToString(),prediction.ToString());
			predictionWriter.writeLine(line);
		}

		public virtual Thread.UncaughtExceptionHandler createExceptionHandler()
		{
			return console.createExceptionHandler();
		}

		public virtual void infoMessage(string s)
		{
			console.infoMessage(s);
		}

	}

	internal class SimpleTextWriter
	{
		private readonly PrintWriter writer;
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: SimpleTextWriter(String fileName) throws java.io.IOException
		internal SimpleTextWriter(string fileName)
		{
			File file = new File(fileName);
			writer = new PrintWriter(new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write));
		}

		internal virtual void writeLine(string line)
		{
			writer.println(line);
			writer.flush();
		}
	}

}