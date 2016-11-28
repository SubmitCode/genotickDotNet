namespace com.alphatica.genotick.processor
{

	using RobotExecutor = com.alphatica.genotick.population.RobotExecutor;
	using RobotExecutorSettings = com.alphatica.genotick.population.RobotExecutorSettings;

	public class RobotExecutorFactory
	{
		private readonly RobotExecutorSettings settings;

		public RobotExecutorFactory(RobotExecutorSettings settings)
		{
			this.settings = settings;
		}

		public virtual RobotExecutor DefaultRobotExecutor
		{
			get
			{
				RobotExecutor executor = SimpleProcessor.createProcessor();
				executor.Settings = settings;
				return executor;
			}
		}
	}

}