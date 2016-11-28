using System.Threading;

namespace com.alphatica.genotick.timepoint
{

	internal class DaemonThreadFactory : ThreadFactory
	{
		private static int counter = 1;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public Thread newThread(@SuppressWarnings("NullableProblems") Runnable runnable)
		public override Thread newThread(("NullableProblems") Runnable runnable)
		{
			Thread thread = new Thread(runnable);
			thread.Daemon = true;
			thread.Name = "TimePointExecutor thread: " + (counter++).ToString();
			return thread;
		}
	}

}