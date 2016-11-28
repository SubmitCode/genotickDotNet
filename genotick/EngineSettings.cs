namespace com.alphatica.genotick.genotick
{

	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;

	internal class EngineSettings
	{
		public TimePoint startTimePoint;
		public TimePoint endTimePoint;
		public bool performTraining;
		public double resultThreshold;
	}

}