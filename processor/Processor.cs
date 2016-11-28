namespace com.alphatica.genotick.processor
{


	using com.alphatica.genotick.instructions;

	public abstract class Processor
	{

		public abstract void execute(DivideRegisterByDouble ins);

		public abstract void execute(MultiplyRegisterByDouble ins);

		public abstract void execute(SwapRegisters ins);

		public abstract void execute(MoveDoubleToRegister ins);

		public abstract void execute(ZeroOutRegister ins);

		public abstract void execute(IncrementRegister ins);

		public abstract void execute(DecrementRegister ins);

		public abstract void execute(AddDoubleToRegister ins);

		public abstract void execute(SubtractDoubleFromRegister ins);

		public abstract void execute(DivideVariableByDouble ins);

		public abstract void execute(MultiplyVariableByDouble ins);

		public abstract void execute(SwapVariables ins);

		public abstract void execute(MoveDoubleToVariable ins);

		public abstract void execute(ZeroOutVariable ins);

		public abstract void execute(IncrementVariable ins);

		public abstract void execute(DecrementVariable ins);

		public abstract void execute(AddDoubleToVariable ins);

		public abstract void execute(SubtractDoubleFromVariable ins);

		public abstract void execute(DivideRegisterByRegister ins);

		public abstract void execute(MultiplyRegisterByRegister ins);

		public abstract void execute(AddRegisterToRegister ins);

		public abstract void execute(SubtractRegisterFromRegister ins);

		public abstract void execute(MoveRegisterToRegister ins);

		public abstract void execute(DivideRegisterByVariable ins);

		public abstract void execute(MultiplyRegisterByVariable ins);

		public abstract void execute(AddRegisterToVariable ins);

		public abstract void execute(SubtractRegisterFromVariable ins);

		public abstract void execute(MoveRegisterToVariable ins);

		public abstract void execute(DivideVariableByVariable ins);

		public abstract void execute(MultiplyVariableByVariable ins);

		public abstract void execute(AddVariableToVariable ins);

		public abstract void execute(SubtractVariableFromVariable ins);

		public abstract void execute(MoveVariableToVariable ins);

		public abstract void execute(DivideVariableByRegister ins);

		public abstract void execute(SubtractVariableFromRegister ins);

		public abstract void execute(MoveVariableToRegister ins);

		public abstract void execute(ReturnRegisterAsResult ins);

		public abstract void execute(ReturnVariableAsResult ins);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("UnusedParameters") public abstract void execute(TerminateInstructionList ins);
		public abstract void execute(TerminateInstructionList ins);

		public abstract void execute(MoveDataToRegister ins);

		public abstract void execute(MoveDataToVariable ins);

		public abstract void execute(MoveRelativeDataToRegister ins);

		public abstract void execute(MoveRelativeDataToVariable ins);

		public abstract void execute(JumpTo ins);

		public abstract void execute(JumpIfVariableGreaterThanRegister ins);

		public abstract void execute(JumpIfVariableLessThanRegister ins);

		public abstract void execute(JumpIfVariableEqualRegister ins);

		public abstract void execute(JumpIfVariableNotEqualRegister ins);

		public abstract void execute(JumpIfRegisterEqualRegister ins);

		public abstract void execute(JumpIfRegisterNotEqualRegister ins);

		public abstract void execute(JumpIfRegisterGreaterThanRegister ins);

		public abstract void execute(JumpIfRegisterLessThanRegister ins);

		public abstract void execute(JumpIfVariableGreaterThanVariable ins);

		public abstract void execute(JumpIfVariableLessThanVariable ins);

		public abstract void execute(JumpIfVariableEqualVariable ins);

		public abstract void execute(JumpIfVariableNotEqualVariable ins);

		public abstract void execute(JumpIfVariableGreaterThanDouble ins);

		public abstract void execute(JumpIfVariableLessThanDouble ins);

		public abstract void execute(JumpIfVariableEqualDouble ins);

		public abstract void execute(JumpIfVariableNotEqualDouble ins);

		public abstract void execute(JumpIfRegisterGreaterThanDouble ins);

		public abstract void execute(JumpIfRegisterLessThanDouble ins);

		public abstract void execute(JumpIfRegisterEqualDouble ins);

		public abstract void execute(JumpIfRegisterNotEqualDouble ins);

		public abstract void execute(JumpIfRegisterEqualZero ins);

		public abstract void execute(JumpIfRegisterNotEqualZero ins);

		public abstract void execute(JumpIfRegisterGreaterThanZero ins);

		public abstract void execute(JumpIfRegisterLessThanZero ins);

		public abstract void execute(JumpIfVariableEqualZero ins);

		public abstract void execute(JumpIfVariableNotEqualZero ins);

		public abstract void execute(JumpIfVariableGreaterThanZero ins);

		public abstract void execute(JumpIfVariableLessThanZero ins);

		public abstract void execute(NaturalLogarithmOfData ins);

		public abstract void execute(NaturalLogarithmOfRegister ins);

		public abstract void execute(NaturalLogarithmOfVariable ins);

		public abstract void execute(SqRootOfRegister ins);

		public abstract void execute(SqRootOfVariable ins);

		public abstract void execute(SumOfColumn ins);

		public abstract void execute(AverageOfColumn ins);

		public abstract void execute(HighestOfColumn ins);

		public abstract void execute(LowestOfColumn ins);

	}

}