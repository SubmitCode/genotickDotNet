using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace com.alphatica.genotick.population
{


	using Outcome = com.alphatica.genotick.genotick.Outcome;
	using Prediction = com.alphatica.genotick.genotick.Prediction;
	using WeightCalculator = com.alphatica.genotick.genotick.WeightCalculator;
	using Instruction = com.alphatica.genotick.instructions.Instruction;
	using InstructionList = com.alphatica.genotick.instructions.InstructionList;


	[Serializable]
	public class Robot
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = -32164662984L;
		private const long serialVersionUID = -32164662984L;
		private static readonly DecimalFormat weightFormat = new DecimalFormat("0.00");

		private RobotName name;
		private readonly int maximumDataOffset;
		private readonly int ignoreColumns;
		private InstructionList mainFunction;
		private int totalChildren;
		private int totalPredictions;
		private int correctPredictions;
		private double inheritedWeight;
		private int totalOutcomes;
		private long outcomesAtLastChild;
		private int bias;

		public static Robot createEmptyRobot(int maximumDataOffset, int ignoreColumns)
		{
			return new Robot(maximumDataOffset, ignoreColumns);
		}

		public virtual int Length
		{
			get
			{
				return mainFunction.Size;
			}
		}

		public virtual RobotName Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}

		public virtual int IgnoreColumns
		{
			get
			{
				return ignoreColumns;
			}
		}

		public virtual double InheritedWeight
		{
			set
			{
				this.inheritedWeight = value;
			}
		}

		private Robot(int maximumDataOffset, int ignoreColumns)
		{
			mainFunction = InstructionList.createInstructionList();
			this.maximumDataOffset = maximumDataOffset;
			this.ignoreColumns = ignoreColumns;
		}

		public virtual void recordPrediction(Prediction prediction)
		{
			if (prediction == Prediction.DOWN)
			{
				bias--;
			}
			else if (prediction == Prediction.UP)
			{
				bias++;
			}
		}

		public virtual void recordOutcomes(IList<Outcome> outcomes)
		{
			foreach (Outcome outcome in outcomes)
			{
				totalOutcomes++;
				if (outcome == Outcome.OUT)
				{
					continue;
				}
				totalPredictions++;
				if (outcome == Outcome.CORRECT)
				{
					correctPredictions++;
				}
			}
		}

		public virtual InstructionList MainFunction
		{
			get
			{
				return mainFunction;
			}
		}

		public virtual int TotalChildren
		{
			get
			{
				return totalChildren;
			}
		}

		public virtual double Weight
		{
			get
			{
				double earnedWeight = WeightCalculator.calculateWeight(this);
				return inheritedWeight + earnedWeight;
			}
		}

		public virtual long OutcomesAtLastChild
		{
			get
			{
				return outcomesAtLastChild;
			}
		}

		public virtual InstructionList MainInstructionList
		{
			set
			{
				mainFunction = value;
			}
		}


		public override string ToString()
		{
			int length = mainFunction.Size;
			return "Name: " + this.name.ToString() + " Outcomes: " + totalOutcomes.ToString() + " Weight: " + weightFormat.format(Weight) + " Length: " + length.ToString() + " Children: " + totalChildren.ToString();
		}

		public virtual void increaseChildren()
		{
			totalChildren++;
			outcomesAtLastChild = totalOutcomes;
		}

		public virtual int MaximumDataOffset
		{
			get
			{
				return maximumDataOffset;
			}
		}

		public virtual int TotalPredictions
		{
			get
			{
				return totalPredictions;
			}
		}

		public virtual int TotalOutcomes
		{
			get
			{
				return totalOutcomes;
			}
		}
		public virtual int CorrectPredictions
		{
			get
			{
				return correctPredictions;
			}
		}

		public virtual int Bias
		{
			get
			{
				return bias;
			}
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String showRobot() throws IllegalAccessException
		public virtual string showRobot()
		{
			StringBuilder sb = new StringBuilder();
			addFields(sb);
			addMainFunction(sb);
			return sb.ToString();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void addMainFunction(StringBuilder sb) throws IllegalAccessException
		private void addMainFunction(StringBuilder sb)
		{
			sb.Append("MainFunction:").Append("\n");
			sb.Append("VariableCount: ").Append(mainFunction.VariablesCount).Append("\n");
			for (int i = 0; i < mainFunction.Size; i++)
			{
				Instruction instruction = mainFunction.getInstruction(i);
				sb.Append(instruction.instructionString()).Append("\n");
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void addFields(StringBuilder sb) throws IllegalAccessException
		private void addFields(StringBuilder sb)
		{
			Field[] fields = this.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
			foreach (Field field in fields)
			{
				if (field.Name.Equals("mainFunction"))
				{
					continue;
				}
				field.Accessible = true;
				if (!Modifier.isStatic(field.Modifiers))
				{
					sb.Append(field.Name).Append(" ").Append(field.get(this).ToString()).Append("\n");
				}
			}
		}
	}

}