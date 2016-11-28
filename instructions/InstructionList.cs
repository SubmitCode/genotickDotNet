using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.instructions
{

	using RandomGenerator = com.alphatica.genotick.genotick.RandomGenerator;
	using UserOutput = com.alphatica.genotick.ui.UserOutput;


	[Serializable]
	public class InstructionList
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 267402795981161615L;
		private const long serialVersionUID = 267402795981161615L;

		private readonly Random random;
		private readonly IList<Instruction> list;
		private readonly int variablesCount;
		private readonly double[] variables;

		private int validateVariableNumber(int index)
		{
			return Math.Abs(index % variablesCount);
		}

		private InstructionList()
		{
			random = RandomGenerator.assignRandom();
			list = new List<>();
			variablesCount = 1 + Math.Abs(random.Next() % 1024);
			variables = new double[variablesCount];
		}

		public static InstructionList createInstructionList()
		{
			return new InstructionList();
		}

		public virtual Instruction getInstruction(int index)
		{
			if (index < 0 || index >= list.Count)
			{
				return new TerminateInstructionList();
			}
			else
			{
				return list[index];
			}
		}

		public virtual double getVariable(int index)
		{
			return variables[validateVariableNumber(index)];
		}

		public virtual void setVariable(int index, double value)
		{
			variables[validateVariableNumber(index)] = value;
		}

		public virtual void zeroOutVariables()
		{
			for (int i = 0; i < variables.Length; i++)
			{
				variables[i] = 0;
			}
		}

		public virtual void addInstruction(Instruction instruction)
		{
			list.Add(instruction);
		}
		public virtual int Size
		{
			get
			{
				return list.Count;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") public void addInstructionAtPosition(Instruction instruction, int position)
		public virtual void addInstructionAtPosition(Instruction instruction, int position)
		{
			position = fixPosition(position);
			list.Insert(position,instruction);
		}

		private int fixPosition(int position)
		{
			if (position >= 0 && position < list.Count)
			{
				return position;
			}
			else
			{
				return random.Next(list.Count);
			}
		}

		public virtual int VariablesCount
		{
			get
			{
				return variablesCount;
			}
		}
	}

}