using System;

namespace com.alphatica.genotick.genotick
{

	public class RandomGenerator
	{
		public static Random assignRandom()
		{
			Random random = new Random();
			string seedString = System.getenv("GENOTICK_RANDOM_SEED");
			if (!string.ReferenceEquals(seedString, null))
			{
				long seed = long.Parse(seedString);
				random.Seed = seed;
			}
			return random;
		}

	}

}