using System;
using System.Collections.Generic;

namespace RPNCalulator
{
    public class OneArgStrategy : IStrategy
    {
        private readonly Dictionary<string, Func<int, int>> _operationFunction;

        public OneArgStrategy()
        {
            _operationFunction = new Dictionary<string, Func<int, int>>
            {
                ["!"] = fst => Factorial(fst)
            };
        }

        private int Factorial(int fact)
        {
            if (fact < 0)
                throw new InvalidOperationException("Can't use factorial on negative numbers.");
            var n = 1;
            for (var i = 1; i <= fact; i++) n = n * i;
            return n;
        }

        public int Compute(string op, Stack<int> stack)
        {
            return _operationFunction[op](stack.Pop());
        }
    }
}