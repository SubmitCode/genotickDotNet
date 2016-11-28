namespace com.alphatica.genotick.genotick
{

	public class Tools
	{
		public static string PidString
		{
			get
			{
				string pid = ManagementFactory.RuntimeMXBean.Name;
				if (pid.Contains("@"))
				{
					return pid.Substring(0, pid.IndexOf('@'));
				}
				else
				{
					return pid;
				}
			}
		}
	}

}