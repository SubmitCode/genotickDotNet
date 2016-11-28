using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace com.alphatica.genotick.instructions
{

	using Mutator = com.alphatica.genotick.mutator.Mutator;
	using Processor = com.alphatica.genotick.processor.Processor;


	[Serializable]
	public abstract class Instruction
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("unused") private static final long serialVersionUID = 6038774498356414583L;
		private const long serialVersionUID = 6038774498356414583L;

		public abstract void executeOn(Processor processor);

		public abstract void mutate(Mutator mutator);

		public abstract Instruction copy();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String instructionString() throws IllegalAccessException
		public virtual string instructionString()
		{
			StringBuilder sb = new StringBuilder();
			string objectName = this.GetType().Name;
			sb.Append(objectName).Append(" ");
			IList<InstructionField> fields = getInheritedFields(this.GetType());
			foreach (InstructionField field in fields)
			{
				sb.Append(field.Name).Append("=").Append(field.Value).Append(" ");
			}
			return sb.ToString();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private java.util.List<InstructionField> getInheritedFields(Class aClass) throws IllegalAccessException
		private IList<InstructionField> getInheritedFields(Type aClass)
		{
			IList<InstructionField> fields = new List<InstructionField>();
			Type check = aClass;
			while (check != typeof(object))
			{
				Field[] declared = check.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
				foreach (Field field in declared)
				{
					field.Accessible = true;
					if (!Modifier.isStatic(field.Modifiers))
					{
						InstructionField instructionField = new InstructionField(field.Name,field.get(this).ToString());
						fields.Add(instructionField);
					}
				}
				check = check.BaseType;
			}
			return fields;
		}
	}


}