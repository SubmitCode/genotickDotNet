using System;

namespace com.alphatica.genotick.genotick
{

	using Robot = com.alphatica.genotick.population.Robot;

	public class WeightCalculator
	{


		public static double calculateWeight(Robot robot)
		{
			return calculateSquareOfDifference(robot);
			//return calculateCorrectVsIncorrectPredictions(robot);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static double calculateCorrectVsIncorrectPredictions(com.alphatica.genotick.population.Robot robot)
		private static double calculateCorrectVsIncorrectPredictions(Robot robot)
		{
			int totalPrediction = robot.TotalPredictions;
			if (totalPrediction == 0)
			{
				return 0;
			}
			int correct = robot.CorrectPredictions;
			int incorrect = robot.TotalPredictions - correct;
			return correct - incorrect;
		}

		private static double calculateSquareOfDifference(Robot robot)
		{
			int correct = robot.CorrectPredictions;
			int incorrect = robot.TotalPredictions - correct;
			bool positive = correct > incorrect;
			double weightAbs = Math.Pow(correct - incorrect,2);
			return positive ? weightAbs : -weightAbs;
		}


	}

}