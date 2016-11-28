namespace com.alphatica.genotick.genotick
{

	using TimePointExecutor = com.alphatica.genotick.timepoint.TimePointExecutor;
	using RobotBreeder = com.alphatica.genotick.breeder.RobotBreeder;
	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using RobotKiller = com.alphatica.genotick.killer.RobotKiller;
	using Population = com.alphatica.genotick.population.Population;

	internal class EngineFactory
	{
		public static Engine getDefaultEngine(EngineSettings engineSettings, MainAppData data, TimePointExecutor timePointExecutor, RobotKiller killer, RobotBreeder breeder, Population population)
		{
			Engine engine = SimpleEngine.Engine;
			engine.setSettings(engineSettings, timePointExecutor, data, killer, breeder, population);
			return engine;
		}
	}
}