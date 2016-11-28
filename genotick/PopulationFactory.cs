namespace com.alphatica.genotick.genotick
{

	using Population = com.alphatica.genotick.population.Population;
	using PopulationDAO = com.alphatica.genotick.population.PopulationDAO;
	using SimplePopulation = com.alphatica.genotick.population.SimplePopulation;

	internal class PopulationFactory
	{

		public static Population getDefaultPopulation(PopulationDAO dao)
		{
			Population population = new SimplePopulation();
			population.Dao = dao;
			return population;
		}
	}

}