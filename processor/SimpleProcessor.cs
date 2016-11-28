using System;

namespace com.alphatica.genotick.processor
{

	using Prediction = com.alphatica.genotick.genotick.Prediction;
	using RobotData = com.alphatica.genotick.genotick.RobotData;
	using AddDoubleToRegister = com.alphatica.genotick.instructions.AddDoubleToRegister;
	using AddDoubleToVariable = com.alphatica.genotick.instructions.AddDoubleToVariable;
	using AddRegisterToRegister = com.alphatica.genotick.instructions.AddRegisterToRegister;
	using AddRegisterToVariable = com.alphatica.genotick.instructions.AddRegisterToVariable;
	using AddVariableToVariable = com.alphatica.genotick.instructions.AddVariableToVariable;
	using AverageOfColumn = com.alphatica.genotick.instructions.AverageOfColumn;
	using DataInstruction = com.alphatica.genotick.instructions.DataInstruction;
	using DecrementRegister = com.alphatica.genotick.instructions.DecrementRegister;
	using DecrementVariable = com.alphatica.genotick.instructions.DecrementVariable;
	using DivideRegisterByDouble = com.alphatica.genotick.instructions.DivideRegisterByDouble;
	using DivideRegisterByRegister = com.alphatica.genotick.instructions.DivideRegisterByRegister;
	using DivideRegisterByVariable = com.alphatica.genotick.instructions.DivideRegisterByVariable;
	using DivideVariableByDouble = com.alphatica.genotick.instructions.DivideVariableByDouble;
	using DivideVariableByRegister = com.alphatica.genotick.instructions.DivideVariableByRegister;
	using DivideVariableByVariable = com.alphatica.genotick.instructions.DivideVariableByVariable;
	using HighestOfColumn = com.alphatica.genotick.instructions.HighestOfColumn;
	using IncrementRegister = com.alphatica.genotick.instructions.IncrementRegister;
	using IncrementVariable = com.alphatica.genotick.instructions.IncrementVariable;
	using Instruction = com.alphatica.genotick.instructions.Instruction;
	using InstructionList = com.alphatica.genotick.instructions.InstructionList;
	using JumpIfRegisterEqualDouble = com.alphatica.genotick.instructions.JumpIfRegisterEqualDouble;
	using JumpIfRegisterEqualRegister = com.alphatica.genotick.instructions.JumpIfRegisterEqualRegister;
	using JumpIfRegisterEqualZero = com.alphatica.genotick.instructions.JumpIfRegisterEqualZero;
	using JumpIfRegisterGreaterThanDouble = com.alphatica.genotick.instructions.JumpIfRegisterGreaterThanDouble;
	using JumpIfRegisterGreaterThanRegister = com.alphatica.genotick.instructions.JumpIfRegisterGreaterThanRegister;
	using JumpIfRegisterGreaterThanZero = com.alphatica.genotick.instructions.JumpIfRegisterGreaterThanZero;
	using JumpIfRegisterLessThanDouble = com.alphatica.genotick.instructions.JumpIfRegisterLessThanDouble;
	using JumpIfRegisterLessThanRegister = com.alphatica.genotick.instructions.JumpIfRegisterLessThanRegister;
	using JumpIfRegisterLessThanZero = com.alphatica.genotick.instructions.JumpIfRegisterLessThanZero;
	using JumpIfRegisterNotEqualDouble = com.alphatica.genotick.instructions.JumpIfRegisterNotEqualDouble;
	using JumpIfRegisterNotEqualRegister = com.alphatica.genotick.instructions.JumpIfRegisterNotEqualRegister;
	using JumpIfRegisterNotEqualZero = com.alphatica.genotick.instructions.JumpIfRegisterNotEqualZero;
	using JumpIfVariableEqualDouble = com.alphatica.genotick.instructions.JumpIfVariableEqualDouble;
	using JumpIfVariableEqualRegister = com.alphatica.genotick.instructions.JumpIfVariableEqualRegister;
	using JumpIfVariableEqualVariable = com.alphatica.genotick.instructions.JumpIfVariableEqualVariable;
	using JumpIfVariableEqualZero = com.alphatica.genotick.instructions.JumpIfVariableEqualZero;
	using JumpIfVariableGreaterThanDouble = com.alphatica.genotick.instructions.JumpIfVariableGreaterThanDouble;
	using JumpIfVariableGreaterThanRegister = com.alphatica.genotick.instructions.JumpIfVariableGreaterThanRegister;
	using JumpIfVariableGreaterThanVariable = com.alphatica.genotick.instructions.JumpIfVariableGreaterThanVariable;
	using JumpIfVariableGreaterThanZero = com.alphatica.genotick.instructions.JumpIfVariableGreaterThanZero;
	using JumpIfVariableLessThanDouble = com.alphatica.genotick.instructions.JumpIfVariableLessThanDouble;
	using JumpIfVariableLessThanRegister = com.alphatica.genotick.instructions.JumpIfVariableLessThanRegister;
	using JumpIfVariableLessThanVariable = com.alphatica.genotick.instructions.JumpIfVariableLessThanVariable;
	using JumpIfVariableLessThanZero = com.alphatica.genotick.instructions.JumpIfVariableLessThanZero;
	using JumpIfVariableNotEqualDouble = com.alphatica.genotick.instructions.JumpIfVariableNotEqualDouble;
	using JumpIfVariableNotEqualRegister = com.alphatica.genotick.instructions.JumpIfVariableNotEqualRegister;
	using JumpIfVariableNotEqualVariable = com.alphatica.genotick.instructions.JumpIfVariableNotEqualVariable;
	using JumpIfVariableNotEqualZero = com.alphatica.genotick.instructions.JumpIfVariableNotEqualZero;
	using JumpTo = com.alphatica.genotick.instructions.JumpTo;
	using LowestOfColumn = com.alphatica.genotick.instructions.LowestOfColumn;
	using MoveDataToRegister = com.alphatica.genotick.instructions.MoveDataToRegister;
	using MoveDataToVariable = com.alphatica.genotick.instructions.MoveDataToVariable;
	using MoveDoubleToRegister = com.alphatica.genotick.instructions.MoveDoubleToRegister;
	using MoveDoubleToVariable = com.alphatica.genotick.instructions.MoveDoubleToVariable;
	using MoveRegisterToRegister = com.alphatica.genotick.instructions.MoveRegisterToRegister;
	using MoveRegisterToVariable = com.alphatica.genotick.instructions.MoveRegisterToVariable;
	using MoveRelativeDataToRegister = com.alphatica.genotick.instructions.MoveRelativeDataToRegister;
	using MoveRelativeDataToVariable = com.alphatica.genotick.instructions.MoveRelativeDataToVariable;
	using MoveVariableToRegister = com.alphatica.genotick.instructions.MoveVariableToRegister;
	using MoveVariableToVariable = com.alphatica.genotick.instructions.MoveVariableToVariable;
	using MultiplyRegisterByDouble = com.alphatica.genotick.instructions.MultiplyRegisterByDouble;
	using MultiplyRegisterByRegister = com.alphatica.genotick.instructions.MultiplyRegisterByRegister;
	using MultiplyRegisterByVariable = com.alphatica.genotick.instructions.MultiplyRegisterByVariable;
	using MultiplyVariableByDouble = com.alphatica.genotick.instructions.MultiplyVariableByDouble;
	using MultiplyVariableByVariable = com.alphatica.genotick.instructions.MultiplyVariableByVariable;
	using NaturalLogarithmOfData = com.alphatica.genotick.instructions.NaturalLogarithmOfData;
	using NaturalLogarithmOfRegister = com.alphatica.genotick.instructions.NaturalLogarithmOfRegister;
	using NaturalLogarithmOfVariable = com.alphatica.genotick.instructions.NaturalLogarithmOfVariable;
	using ReturnRegisterAsResult = com.alphatica.genotick.instructions.ReturnRegisterAsResult;
	using ReturnVariableAsResult = com.alphatica.genotick.instructions.ReturnVariableAsResult;
	using SqRootOfRegister = com.alphatica.genotick.instructions.SqRootOfRegister;
	using SqRootOfVariable = com.alphatica.genotick.instructions.SqRootOfVariable;
	using SubtractDoubleFromRegister = com.alphatica.genotick.instructions.SubtractDoubleFromRegister;
	using SubtractDoubleFromVariable = com.alphatica.genotick.instructions.SubtractDoubleFromVariable;
	using SubtractRegisterFromRegister = com.alphatica.genotick.instructions.SubtractRegisterFromRegister;
	using SubtractRegisterFromVariable = com.alphatica.genotick.instructions.SubtractRegisterFromVariable;
	using SubtractVariableFromRegister = com.alphatica.genotick.instructions.SubtractVariableFromRegister;
	using SubtractVariableFromVariable = com.alphatica.genotick.instructions.SubtractVariableFromVariable;
	using SumOfColumn = com.alphatica.genotick.instructions.SumOfColumn;
	using SwapRegisters = com.alphatica.genotick.instructions.SwapRegisters;
	using SwapVariables = com.alphatica.genotick.instructions.SwapVariables;
	using TerminateInstructionList = com.alphatica.genotick.instructions.TerminateInstructionList;
	using ZeroOutRegister = com.alphatica.genotick.instructions.ZeroOutRegister;
	using ZeroOutVariable = com.alphatica.genotick.instructions.ZeroOutVariable;
	using Robot = com.alphatica.genotick.population.Robot;
	using RobotExecutor = com.alphatica.genotick.population.RobotExecutor;
	using RobotExecutorSettings = com.alphatica.genotick.population.RobotExecutorSettings;

	public class SimpleProcessor : Processor, RobotExecutor
	{

		private const int MAX_JUMP = 255;
		private readonly double[] registers = new double[com.alphatica.genotick.population.RobotExecutor_Fields.totalRegisters];
		private Robot robot;
		private RobotData data;
		private int dataColumns;
		private double robotResult;
		private bool finished;
		private InstructionList instructionList;
		private bool terminateInstructionList;
		private int changeInstructionPointer;
		private int totalInstructionExecuted;
		private int instructionLimitMultiplier;
		private int robotInstructionLimit;
		private int dataMaximumOffset;
		private int ignoreColumns;

		public static SimpleProcessor createProcessor()
		{
			return new SimpleProcessor();
		}

		public virtual Prediction executeRobot(RobotData robotData, Robot robot)
		{
			prepare(robotData, robot);
			robotInstructionLimit = robot.Length * instructionLimitMultiplier;
			try
			{
				return executeRobotMain();
			}
			catch (System.Exception ex) when (ex is NotEnoughDataException || ex is TooManyInstructionsExecuted || ex is ArithmeticException)
			{
				return Prediction.OUT;
			}
		}

		public virtual RobotExecutorSettings Settings
		{
			set
			{
				instructionLimitMultiplier = value.instructionLimit;
			}
		}

		private void prepare(RobotData robotData, Robot robot)
		{
			this.robot = robot;
			this.data = robotData;
			dataColumns = data.Columns;
			finished = false;
			instructionList = null;
			terminateInstructionList = false;
			changeInstructionPointer = 0;
			totalInstructionExecuted = 0;
			dataMaximumOffset = robot.MaximumDataOffset;
			ignoreColumns = robot.IgnoreColumns;
			zeroOutRegisters();
		}

		private void zeroOutRegisters()
		{
			Arrays.fill(registers, 0.0);
		}

		private Prediction executeRobotMain()
		{
			executeInstructionList(robot.MainFunction);
			if (finished)
			{
				return Prediction.getPrediction(robotResult);
			}
			else
			{
				return Prediction.getPrediction(registers[0]);
			}
		}

		private void executeInstructionList(InstructionList list)
		{
			list.zeroOutVariables();
			terminateInstructionList = false;
			int instructionPointer = 0;
			instructionList = list;
			do
			{
				Instruction instruction = list.getInstruction(instructionPointer++);
				instruction.executeOn(this);
				totalInstructionExecuted++;
				if (totalInstructionExecuted > robotInstructionLimit)
				{
					break;
				}
				instructionPointer = Math.Abs((instructionPointer + changeInstructionPointer) % instructionList.Size);
				changeInstructionPointer = 0;
			} while (!terminateInstructionList && !finished);
		}


		private SimpleProcessor()
		{
		}

		public override void execute(SwapRegisters ins)
		{
			int reg1 = ins.Register1;
			int reg2 = ins.Register2;
			double tmp = registers[reg1];
			registers[reg1] = registers[reg2];
			registers[reg2] = tmp;
		}

		public override void execute(IncrementRegister ins)
		{
			int reg = ins.Register;
			registers[reg]++;
		}

		public override void execute(MoveDoubleToRegister ins)
		{
			int reg = ins.Register;
			registers[reg] = ins.DoubleArgument;
		}

		public override void execute(AddDoubleToRegister ins)
		{
			int reg = ins.Register;
			registers[reg] += ins.DoubleArgument;
		}

		public override void execute(ZeroOutRegister ins)
		{
			int reg = ins.Register;
			registers[reg] = 0;
		}

		public override void execute(ReturnRegisterAsResult ins)
		{
			int reg = ins.Register;
			robotResult = registers[reg];
			finished = true;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public void execute(@SuppressWarnings("unused") com.alphatica.genotick.instructions.TerminateInstructionList ins)
		public override void execute(("unused") TerminateInstructionList ins)
		{
			terminateInstructionList = true;
		}

		public override void execute(DecrementRegister ins)
		{
			int reg = ins.Register;
			registers[reg]--;
		}

		public override void execute(MoveRegisterToRegister ins)
		{
			int reg1 = ins.Register1;
			int reg2 = ins.Register2;
			registers[reg1] = registers[reg2];
		}

		public override void execute(MoveVariableToRegister ins)
		{
			int reg = ins.Register;
			registers[reg] = instructionList.getVariable(ins.VariableArgument);
		}

		public override void execute(MoveRegisterToVariable ins)
		{
			int reg = ins.Register;
			instructionList.setVariable(ins.VariableArgument, registers[reg]);
		}

		public override void execute(MultiplyRegisterByRegister ins)
		{
			int reg1 = ins.Register1;
			int reg2 = ins.Register2;
			registers[reg1] *= registers[reg2];
		}

		public override void execute(MultiplyRegisterByVariable ins)
		{
			int reg = ins.Register;
			registers[reg] *= instructionList.getVariable(ins.VariableArgument);
		}

		public override void execute(MultiplyVariableByVariable ins)
		{
			double var1 = instructionList.getVariable(ins.Variable1Argument);
			double var2 = instructionList.getVariable(ins.Variable2Argument);
			instructionList.setVariable(ins.Variable1Argument, var1 * var2);
		}

		public override void execute(SubtractDoubleFromRegister ins)
		{
			int reg = ins.Register;
			registers[reg] -= ins.DoubleArgument;
		}

		public override void execute(MoveDoubleToVariable ins)
		{
			instructionList.setVariable(ins.VariableArgument, ins.DoubleArgument);
		}

		public override void execute(DivideRegisterByRegister ins)
		{
			int reg1 = ins.Register1;
			int reg2 = ins.Register2;
			registers[reg1] /= registers[reg2];
		}

		public override void execute(DivideRegisterByVariable ins)
		{
			int reg = ins.Register;
			double @var = instructionList.getVariable(ins.VariableArgument);
			registers[reg] /= @var;
		}

		public override void execute(DivideVariableByVariable ins)
		{
			double var1 = instructionList.getVariable(ins.Variable1Argument);
			double var2 = instructionList.getVariable(ins.Variable2Argument);
			instructionList.setVariable(ins.Variable1Argument, var1 / var2);
		}

		public override void execute(DivideVariableByRegister ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			int reg = ins.Register;
			instructionList.setVariable(ins.VariableArgument, @var / registers[reg]);
		}

		public override void execute(ReturnVariableAsResult ins)
		{
			robotResult = instructionList.getVariable(ins.VariableArgument);
			finished = true;
		}

		public override void execute(AddRegisterToRegister ins)
		{
			int reg1 = ins.Register1;
			int reg2 = ins.Register2;
			registers[reg1] += registers[reg2];
		}

		public override void execute(SubtractRegisterFromRegister ins)
		{
			int reg1 = ins.Register1;
			int reg2 = ins.Register2;
			registers[reg1] -= registers[reg2];
		}

		public override void execute(MoveDataToRegister ins)
		{
			int reg = ins.Register;
			int offset = fixOffset(ins.DataOffsetIndex);
			int column = fixColumn(ins.DataColumnIndex);
			registers[reg] = data.getData(column, offset);
		}


		public override void execute(MoveDataToVariable ins)
		{
			int offset = fixOffset(ins.DataOffsetIndex);
			int column = fixColumn(ins.DataColumnIndex);
			double value = data.getData(column, offset);
			instructionList.setVariable(ins.VariableArgument,value);
		}

		public override void execute(MoveRelativeDataToRegister ins)
		{
			int reg = ins.Register;
			int varOffset = getRelativeOffset(ins);
			int column = fixColumn(ins.DataColumnIndex);
			registers[reg] = data.getData(column, varOffset);
		}

		public override void execute(MoveRelativeDataToVariable ins)
		{
			int varOffset = getRelativeOffset(ins);
			int column = fixColumn(ins.DataColumnIndex);
			double value = data.getData(column, varOffset);
			instructionList.setVariable(ins.VariableArgument, value);
		}

		public override void execute(JumpTo ins)
		{
			jumpTo(ins.Address);
		}
		private void jumpTo(int jumpAddress)
		{
			changeInstructionPointer = (jumpAddress % MAX_JUMP);
		}

		public override void execute(JumpIfVariableGreaterThanRegister ins)
		{
			double register = registers[ins.Register];
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable > register)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableLessThanRegister ins)
		{
			double register = registers[ins.Register];
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable < register)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableEqualRegister ins)
		{
			double register = registers[ins.Register];
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (0 == variable.CompareTo(register))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableNotEqualRegister ins)
		{
			double register = registers[ins.Register];
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (0 != variable.CompareTo(register))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterEqualRegister ins)
		{
			double register1 = registers[ins.Register1];
			double register2 = registers[ins.Register2];
			if (0 == register1.CompareTo(register2))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterNotEqualRegister ins)
		{
			double register1 = registers[ins.Register1];
			double register2 = registers[ins.Register2];
			if (0 != register1.CompareTo(register2))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterGreaterThanRegister ins)
		{
			double register1 = registers[ins.Register1];
			double register2 = registers[ins.Register2];
			if (register1.CompareTo(register2) > 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterLessThanRegister ins)
		{
			double register1 = registers[ins.Register1];
			double register2 = registers[ins.Register2];
			if (register1.CompareTo(register2) < 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableGreaterThanVariable ins)
		{
			double variable1 = instructionList.getVariable(ins.Variable1Argument);
			double variable2 = instructionList.getVariable(ins.Variable2Argument);
			if (variable1.CompareTo(variable2) > 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableLessThanVariable ins)
		{
			double variable1 = instructionList.getVariable(ins.Variable1Argument);
			double variable2 = instructionList.getVariable(ins.Variable2Argument);
			if (variable1.CompareTo(variable2) < 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableEqualVariable ins)
		{
			double variable1 = instructionList.getVariable(ins.Variable1Argument);
			double variable2 = instructionList.getVariable(ins.Variable2Argument);
			if (0 == variable1.CompareTo(variable2))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableNotEqualVariable ins)
		{
			double variable1 = instructionList.getVariable(ins.Variable1Argument);
			double variable2 = instructionList.getVariable(ins.Variable2Argument);
			if (0 != variable1.CompareTo(variable2))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableGreaterThanDouble ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable.CompareTo(ins.DoubleArgument) > 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableLessThanDouble ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable.CompareTo(ins.DoubleArgument) < 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableEqualDouble ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (0 == variable.CompareTo(ins.DoubleArgument))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableNotEqualDouble ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (0 != variable.CompareTo(ins.DoubleArgument))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterGreaterThanDouble ins)
		{
			double register = registers[ins.Register];
			if (register.CompareTo(ins.DoubleArgument) > 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterLessThanDouble ins)
		{
			double register = registers[ins.Register];
			if (register.CompareTo(ins.DoubleArgument) < 0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterEqualDouble ins)
		{
			double register = registers[ins.Register];
			if (0 == register.CompareTo(ins.DoubleArgument))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterNotEqualDouble ins)
		{
			double register = registers[ins.Register];
			if (0 != register.CompareTo(ins.DoubleArgument))
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterEqualZero ins)
		{
			double register = registers[ins.Register];
			if (register == 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterNotEqualZero ins)
		{
			double register = registers[ins.Register];
			if (register != 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterGreaterThanZero ins)
		{
			double register = registers[ins.Register];
			if (register > 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfRegisterLessThanZero ins)
		{
			double register = registers[ins.Register];
			if (register < 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableEqualZero ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable == 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableNotEqualZero ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable != 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableGreaterThanZero ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable > 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(JumpIfVariableLessThanZero ins)
		{
			double variable = instructionList.getVariable(ins.VariableArgument);
			if (variable < 0.0)
			{
				jumpTo(ins.Address);
			}
		}

		public override void execute(NaturalLogarithmOfData ins)
		{
			int column = fixColumn(ins.DataColumnIndex);
			int offset = fixOffset(ins.DataOffsetIndex);
			double value = Math.Log(data.getData(column,offset));
			registers[ins.Register] = value;
		}

		public override void execute(NaturalLogarithmOfRegister ins)
		{
			double value = Math.Log(registers[ins.Register2]);
			registers[ins.Register1] = value;
		}

		public override void execute(NaturalLogarithmOfVariable ins)
		{
			double value = Math.Log(instructionList.getVariable(ins.Variable2Argument));
			instructionList.setVariable(ins.Variable1Argument,value);
		}

		public override void execute(SqRootOfRegister ins)
		{
			double value = Math.Pow(registers[ins.Register2], 0.5);
			registers[ins.Register1] = value;
		}

		public override void execute(SqRootOfVariable ins)
		{
			double value = Math.Pow(instructionList.getVariable(ins.Variable2Argument), 0.5);
			instructionList.setVariable(ins.Variable1Argument,value);
		}

		public override void execute(SumOfColumn ins)
		{
			int column = fixColumn(ins.Register1);
			int length = fixOffset(registers[ins.Register2]);
			registers[0] = getSum(column,length);
		}

		public override void execute(AverageOfColumn ins)
		{
			int column = fixColumn(ins.Register1);
			int length = fixOffset(registers[ins.Register2]);
			double sum = getSum(column, length);
			registers[0] = sum / length;
		}


		private double getSum(int column, int length)
		{
			double sum = 0;
			for (int i = 0; i < length; i++)
			{
				sum += data.getData(column,i);
			}
			return sum;
		}

		public override void execute(SwapVariables ins)
		{
			double var1 = instructionList.getVariable(ins.Variable1Argument);
			double var2 = instructionList.getVariable(ins.Variable2Argument);
			instructionList.setVariable(ins.Variable1Argument, var2);
			instructionList.setVariable(ins.Variable2Argument, var1);
		}

		public override void execute(SubtractVariableFromRegister ins)
		{
			int reg = ins.Register;
			registers[reg] -= instructionList.getVariable(ins.VariableArgument);
		}

		public override void execute(DivideRegisterByDouble ins)
		{
			int reg = ins.Register;
			registers[reg] /= ins.DoubleArgument;
		}

		public override void execute(MultiplyRegisterByDouble ins)
		{
			int reg = ins.Register;
			registers[reg] *= ins.DoubleArgument;
		}

		public override void execute(DivideVariableByDouble ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			double result = @var / ins.DoubleArgument;
			instructionList.setVariable(ins.VariableArgument, result);
		}

		public override void execute(MultiplyVariableByDouble ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			double result = @var * ins.DoubleArgument;
			instructionList.setVariable(ins.VariableArgument, result);
		}

		public override void execute(ZeroOutVariable ins)
		{
			instructionList.setVariable(ins.VariableArgument, 0.0);
		}

		public override void execute(IncrementVariable ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			@var++;
			instructionList.setVariable(ins.VariableArgument, @var);
		}

		public override void execute(DecrementVariable ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			@var--;
			instructionList.setVariable(ins.VariableArgument, @var);
		}

		public override void execute(AddDoubleToVariable ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			double result = @var + ins.DoubleArgument;
			instructionList.setVariable(ins.VariableArgument, result);
		}

		public override void execute(SubtractDoubleFromVariable ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			double result = @var - ins.DoubleArgument;
			instructionList.setVariable(ins.VariableArgument, result);
		}

		public override void execute(AddRegisterToVariable ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			int register = ins.Register;
			double result = @var + registers[register];
			instructionList.setVariable(ins.VariableArgument, result);
		}

		public override void execute(SubtractRegisterFromVariable ins)
		{
			double @var = instructionList.getVariable(ins.VariableArgument);
			int register = ins.Register;
			double result = @var - registers[register];
			instructionList.setVariable(ins.VariableArgument, result);
		}

		public override void execute(AddVariableToVariable ins)
		{
			double var1 = instructionList.getVariable(ins.Variable1Argument);
			double var2 = instructionList.getVariable(ins.Variable2Argument);
			double result = var1 + var2;
			instructionList.setVariable(ins.Variable1Argument, result);
		}

		public override void execute(SubtractVariableFromVariable ins)
		{
			double var1 = instructionList.getVariable(ins.Variable1Argument);
			double var2 = instructionList.getVariable(ins.Variable2Argument);
			double result = var1 - var2;
			instructionList.setVariable(ins.Variable1Argument,result);
		}

		public override void execute(MoveVariableToVariable ins)
		{
			double @var = instructionList.getVariable(ins.Variable2Argument);
			instructionList.setVariable(ins.Variable1Argument,@var);
		}

		public override void execute(HighestOfColumn ins)
		{
			int column = fixColumn(ins.Register1);
			int length = fixOffset(registers[ins.Register2]);
			double highest = data.getData(column,0);
			for (int i = 1; i < length; i++)
			{
				double check = data.getData(column,i);
				if (check > highest)
				{
					highest = check;
				}
			}
			registers[0] = highest;
		}

		public override void execute(LowestOfColumn ins)
		{
			int column = fixColumn(ins.Register1);
			int length = fixOffset(registers[ins.Register2]);
			double lowest = data.getData(column,0);
			for (int i = 1; i < length; i++)
			{
				double check = data.getData(column,i);
				if (check < lowest)
				{
					lowest = check;
				}
			}
			registers[0] = lowest;
		}

		private int getRelativeOffset(DataInstruction ins)
		{
			double value = instructionList.getVariable(ins.DataOffsetIndex);
			return fixOffset(value);
		}

		private int fixOffset(double value)
		{
			return (int)Math.Abs(value % dataMaximumOffset);
		}
		private int fixColumn(double value)
		{
			return ignoreColumns + (int)Math.Abs(value % (dataColumns - ignoreColumns));
		}


	}

}