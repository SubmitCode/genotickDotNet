using System.Threading;

namespace com.alphatica.genotick.ui
{

	using DataSetName = com.alphatica.genotick.data.DataSetName;
	using Prediction = com.alphatica.genotick.genotick.Prediction;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;

	public interface UserOutput
	{
		void errorMessage(string message);

		void warningMessage(string message);

		void reportProfitForTimePoint(TimePoint timePoint, double cumulativeProfit, double timePointProfit);

		void showPrediction(TimePoint timePoint, DataSetName name, Prediction prediction);

		Thread.UncaughtExceptionHandler createExceptionHandler();

		void infoMessage(string s);
	}

}