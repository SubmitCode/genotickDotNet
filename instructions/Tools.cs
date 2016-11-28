namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;

	internal class Tools
	{
		internal static double mutateDouble(double argument, Mutator mutator)
		{
			double next = argument * mutator.NextDouble;
			if (argument > 0)
			{
				 return argument + next;
			}
			else
			{
				return argument - next;
			}
		}
	}

}