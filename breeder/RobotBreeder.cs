using System.Collections.Generic;

namespace com.alphatica.genotick.breeder
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;
	using Population = com.alphatica.genotick.population.Population;
	using RobotInfo = com.alphatica.genotick.population.RobotInfo;

	public interface RobotBreeder
	{

		void breedPopulation(Population population, IList<RobotInfo> robotInfos);

		void setSettings(BreederSettings breederSettings, Mutator mutator);

	}

}