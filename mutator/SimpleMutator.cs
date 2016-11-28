using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.alphatica.genotick.mutator
{

	using RandomGenerator = com.alphatica.genotick.genotick.RandomGenerator;
	using Instruction = com.alphatica.genotick.instructions.Instruction;
	using Processor = com.alphatica.genotick.processor.Processor;


	internal class SimpleMutator : Mutator
	{
		private MutatorSettings settings;
		private readonly Random random;
//JAVA TO C# CONVERTER TODO TASK: There is no .NET equivalent to the Java 'super' constraint:
//ORIGINAL LINE: private final java.util.List<Class< ? super com.alphatica.genotick.instructions.Instruction>> instructionList;
//JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
		private readonly IList<Type> instructionList;
		private int totalInstructions;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private SimpleMutator() throws ClassNotFoundException
		private SimpleMutator()
		{
			random = RandomGenerator.assignRandom();
			instructionList = new List<>();
			buildInstructionList(instructionList);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unchecked") private void buildInstructionList(java.util.List<Class<? super com.alphatica.genotick.instructions.Instruction>> instructionList) throws ClassNotFoundException
//JAVA TO C# CONVERTER TODO TASK: There is no .NET equivalent to the Java 'super' constraint:
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
		private void buildInstructionList(IList<Type> instructionList)
		{
			Type processorClass = typeof(Processor);
			Method[] methods = processorClass.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
			foreach (Method m in methods)
			{
				Type[] types = m.ParameterTypes;
				foreach (Type t in types)
				{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
					Type<Instruction> c = (Type<Instruction>)Type.GetType(t.FullName);
					instructionList.Add(c);
				}
			}
			totalInstructions = instructionList.Count;
		}

		internal static Mutator Instance
		{
			get
			{
				try
				{
					return new SimpleMutator();
				}
				catch (ClassNotFoundException ex)
				{
					throw new Exception("Unable to get Class", ex);
				}
			}
		}

		public virtual Instruction RandomInstruction
		{
			get
			{
				int index = random.Next(totalInstructions);
				return createNewInstruction(index);
			}
		}

		private Instruction createNewInstruction(int index)
		{
			try
			{
				return (Instruction) instructionList[index].newInstance();
			}
			catch (System.Exception e) when (e is InstantiationException || e is IllegalAccessException)
			{
				throw new Exception(e);
			}
		}

		public virtual bool AllowInstructionMutation
		{
			get
			{
				return random.NextDouble() < settings.InstructionMutationProbability;
			}
		}

		public virtual bool AllowNewInstruction
		{
			get
			{
				return random.NextDouble() < settings.NewInstructionProbability;
			}
		}

		public virtual int NextInt
		{
			get
			{
				return random.Next();
			}
		}

		public virtual double NextDouble
		{
			get
			{
				if (random.nextBoolean())
				{
					return random.NextDouble();
				}
				else
				{
					return -random.NextDouble();
				}
			}
		}

		public virtual sbyte NextByte
		{
			get
			{
				return (sbyte)random.Next();
			}
		}

		public virtual MutatorSettings Settings
		{
			set
			{
				this.settings = value;
			}
		}

		public virtual bool skipNextInstruction()
		{
			return random.NextDouble() < settings.SkipInstructionProbability;
		}
	}

}