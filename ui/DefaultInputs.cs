namespace com.alphatica.genotick.ui
{

	using MainSettings = com.alphatica.genotick.genotick.MainSettings;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") class DefaultInputs extends BasicUserInput
	internal class DefaultInputs : BasicUserInput
	{
		public override MainSettings getSettings(UserOutput output)
		{
			return MainSettings.Settings;
		}
	}

}