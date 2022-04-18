namespace Calculator.App
{
    public interface IOperationType
    {
        int Value { get; }
        int Operate(int number);
        int Undo(int number);
    }
}
