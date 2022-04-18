namespace Calculator.App
{
    public interface ICalculator
    {
        ICalculator Minus(int n);
        ICalculator Plus(int n);
        ICalculator Redo();
        int Result();
        ICalculator Save();
        ICalculator Seed(int n);
        ICalculator Undo();
    }
}