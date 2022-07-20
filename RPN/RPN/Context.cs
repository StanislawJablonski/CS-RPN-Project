using System;

namespace RPNCalulator
{
    public class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public IStrategy SetStrategy(string operation)
        {
            _strategy = ChooseStrategyForOperation(operation);
            return _strategy;
        }

        public int ExecuteOperation(string operation, Stack<int> stack)
        {
            return _strategy.Compute(operation, stack);
        }

        private IStrategy ChooseStrategyForOperation(string operation)
        {
            if (IsTwoArgsOp(operation)) return new TwoArgsStrategy();
            if (IsOneArgOp(operation)) return new OneArgStrategy();
            throw new InvalidOperationException();
        }

        private bool IsTwoArgsOp(string input)
        {
            return input.Equals("+") || input.Equals("-") ||
                   input.Equals("*") || input.Equals("/");
        }

        private bool IsOneArgOp(string input)
        {
            return input.Equals("!");
        }
    }
}