namespace Calculator.App
{
    public class PlusOperation : IOperationType
    {
        public int Value { get; private set; }
        public bool CanRedo { get; private set; }

        public PlusOperation(int plus)
        {
            Value = plus;
        }

        public int Operate(int number)
        {
            return number + Value;
        }

        public int Undo(int number)
        {
            CanRedo = true;
            return number - Value;
        }
    }
}
