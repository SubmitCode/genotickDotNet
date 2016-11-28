namespace com.alphatica.genotick.data
{

	using UserOutput = com.alphatica.genotick.ui.UserOutput;

	public interface DataLoader
	{
		MainAppData createRobotData(UserOutput output);
	}

}