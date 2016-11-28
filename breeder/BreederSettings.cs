namespace com.alphatica.genotick.breeder
{

	public class BreederSettings
	{
		public readonly long outcomesBetweenBreeding;
		public readonly double inheritedWeightPercent;
		public readonly long minimumOutcomesToAllowBreeding;
		public readonly double randomRobots;
		public readonly int dataMaximumOffset;
		public readonly int ignoreColumns;

		public BreederSettings(long timeBetweenChildren, double inheritedWeightPercent, long minimumParentAge, double randomRobots, int dataMaximumOffset, int ignoreColumns)
		{
			this.outcomesBetweenBreeding = timeBetweenChildren;
			this.inheritedWeightPercent = inheritedWeightPercent;
			this.minimumOutcomesToAllowBreeding = minimumParentAge;
			this.randomRobots = randomRobots;
			this.dataMaximumOffset = dataMaximumOffset;
			this.ignoreColumns = ignoreColumns;
		}
	}

}