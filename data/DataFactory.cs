namespace com.alphatica.genotick.data
{

	public class DataFactory
	{
		public static DataLoader getDefaultLoader(string args)
		{
			return new FileSystemDataLoader(args);
		}
	}

}