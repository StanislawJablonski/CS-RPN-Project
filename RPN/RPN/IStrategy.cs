namespace RPNCalulator
{
    public interface IStrategy
    {
        int Compute(string operation, Stack<int> stack);
    }
}