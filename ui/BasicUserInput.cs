namespace com.alphatica.genotick.ui
{

	using DataFactory = com.alphatica.genotick.data.DataFactory;
	using DataLoader = com.alphatica.genotick.data.DataLoader;
	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using Simulation = com.alphatica.genotick.genotick.Simulation;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("WeakerAccess") public abstract class BasicUserInput implements UserInput
	public abstract class BasicUserInput : UserInput
	{
		public abstract com.alphatica.genotick.genotick.MainSettings getSettings(UserOutput output);
		private Simulation simulation;

		public virtual Simulation Simulation
		{
			set
			{
				this.simulation = value;
			}
			get
			{
				return simulation;
			}
		}


		public virtual MainAppData getData(string settings, UserOutput output)
		{
			DataLoader dl = DataFactory.getDefaultLoader(settings);
			return dl.createRobotData(output);
		}

	}

}