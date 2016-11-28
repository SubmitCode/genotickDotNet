using System;
using System.Threading;

namespace com.alphatica.genotick.ui
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using Prediction = com.alphatica.genotick.genotick.Prediction;
	using Tools = com.alphatica.genotick.genotick.Tools;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;
	using FileUtils = org.apache.commons.io.FileUtils;


	internal class ConsoleOutput : UserOutput
	{

		private File logFile = new File(string.Format("genotick-log-{0}.txt", Tools.PidString));

		public virtual void errorMessage(string message)
		{
			log("Error: " + message);
		}

		public virtual void warningMessage(string message)
		{
			log("Warning: " + message);
		}

		public virtual void reportProfitForTimePoint(TimePoint timePoint, double cumulativeProfit, double timePointProfit)
		{
			log("Profit for " + timePoint.ToString() + ": " + "Cumulative profit: " + cumulativeProfit + " " + "TimePoint's profit: " + timePointProfit);
		}

		public virtual void showPrediction(TimePoint timePoint, DataSetName name, Prediction prediction)
		{
			log(string.Format("{0} prediction on {1} for the next trade: {2}", name.ToString(),timePoint.ToString(),prediction.ToString()));
		}

		public virtual Thread.UncaughtExceptionHandler createExceptionHandler()
		{
			return (thread, throwable) =>
		{
			log("Exception in thread: " + thread.Name);
			foreach (StackTraceElement element in throwable.StackTrace)
			{
				log(element.ToString());
			}
		};
		}

		public virtual void infoMessage(string s)
		{
			Console.WriteLine(s);
		}

		private void log(string @string)
		{
			Console.WriteLine(@string);
			try
			{
				FileUtils.write(logFile, @string + Environment.NewLine, true);
			}
			catch (IOException e)
			{
				Console.Error.WriteLine("Unable to write to file " + logFile.Path + ": " + e.Message);
				Environment.Exit(1);
			}
		}

	}

}