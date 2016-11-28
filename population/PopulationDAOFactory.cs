namespace com.alphatica.genotick.population
{

	public class PopulationDAOFactory
	{
		public static PopulationDAO getDefaultDAO(string dao)
		{
			switch (dao)
			{
				case "":
					return new PopulationDAORAM();
				default:
					return new PopulationDAOFileSystem(dao);
			}
		}
	}

}