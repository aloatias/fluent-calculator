namespace Calculator.App
{
    public class MyCalculator : ICalculator
    {
        private bool _isSaved = false;
        private int _result;
        private readonly Stack<IOperationType> _operations = new();
        private readonly Stack<IOperationType> _undoneOperations = new();
        private readonly Stack<IOperationType> _redoneOperations = new();

        public ICalculator Minus(int n)
        {
            var operation = new MinusOperation(n);
            _result = operation.Operate(_result);
            _operations.Push(operation);

            return this;
        }

        public ICalculator Plus(int n)
        {
            var operation = new PlusOperation(n);
            _result = operation.Operate(_result);
            _operations.Push(operation);

            return this;
        }

        public ICalculator Redo()
        {
            if (CheckFeasability(_undoneOperations))
            {
                var operation = _undoneOperations.Pop();
                _result = operation.Operate(_result);
                _redoneOperations.Push(operation);
            }

            return this;
        }

        public int Result()
        {
            return _result;
        }

        public ICalculator Save()
        {
            _isSaved = true;
            return this;
        }

        public ICalculator Seed(int n)
        {
            _result = n;
            return this;
        }

        public ICalculator Undo()
        {
            if (CheckFeasability(_operations))
            {
                var operation = _operations.Pop();
                _result = operation.Undo(_result);
                _undoneOperations.Push(operation);
            }

            return this;
        }

        private bool CheckFeasability(Stack<IOperationType> operations)
        {
            return operations.Any() && !_isSaved;
        }
    }
}
