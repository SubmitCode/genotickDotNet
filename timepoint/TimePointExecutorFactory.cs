namespace com.alphatica.genotick.timepoint
{

	using DataSetExecutor = com.alphatica.genotick.genotick.DataSetExecutor;
	using RobotExecutorFactory = com.alphatica.genotick.processor.RobotExecutorFactory;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;

	public class TimePointExecutorFactory
	{
		public static TimePointExecutor getDefaultExecutor(DataSetExecutor dataSetExecutor, RobotExecutorFactory robotExecutorFactory, UserOutput output)
		{
			TimePointExecutor executor = new SimpleTimePointExecutor(output);
			executor.setSettings(dataSetExecutor, robotExecutorFactory);
			return executor;
		}


	}

}