using System.Collections.Generic;

namespace com.alphatica.genotick.data
{


	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	public class FileSystemDataLoader : DataLoader
	{
		private readonly string[] paths;

		public FileSystemDataLoader(params string[] args)
		{
			paths = args;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: @Override public MainAppData createRobotData(com.alphatica.genotick.ui.UserOutput output) throws DataException
		public virtual MainAppData createRobotData(UserOutput output)
		{
			return loadData(output);
		}

		private MainAppData loadData(UserOutput output)
		{
			MainAppData data = new MainAppData();
			string extension = ".csv";
			IList<string> names = DataUtils.listFiles(extension,paths);
			if (names == null)
			{
				throw new DataException("Unable to list files");
			}
			foreach (string name in names)
			{
				output.infoMessage("Reading file " + name);
				data.addDataSet(createDataSet(name,output));
			}
			if (data.Empty)
			{
				throw new DataException("No files to read!");
			}
			return data;

		}
		private DataSet createDataSet(string name, UserOutput output)
		{
			try
			{
					using (System.IO.StreamReader br = new System.IO.StreamReader(new File(name)))
					{
					IList<Number []> lines = DataUtils.createLineList(br);
					output.infoMessage("Got " + lines.Count + " lines");
					return new DataSet(lines,name);
					}
			}
			catch (System.Exception e) when (e is IOException || e is DataException)
			{
				DataException de = new DataException("Unable to process file: " + name);
				de.initCause(e);
				throw de;
			}
		}
	}



}