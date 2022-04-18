namespace Calculator.App
{
    public class MinusOperation : IOperationType
    {
        public int Value { get; private set; }

        public MinusOperation(int minus)
        {
            Value = minus;
        }

        public int Operate(int number)
        {
            return number - Value;
        }

        public int Undo(int number)
        {
            return number + Value;
        }
    }
}
