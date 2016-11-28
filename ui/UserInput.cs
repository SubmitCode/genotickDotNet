namespace com.alphatica.genotick.ui
{

	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using Simulation = com.alphatica.genotick.genotick.Simulation;
	using MainSettings = com.alphatica.genotick.genotick.MainSettings;

	public interface UserInput
	{
		MainSettings getSettings(UserOutput output);
		Simulation Simulation {set;get;}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") com.alphatica.genotick.genotick.Simulation getSimulation();
		MainAppData getData(string settings, UserOutput output);
	}

}