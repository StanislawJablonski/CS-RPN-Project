using System;
using System.Collections.Generic;

namespace RPNCalulator
{
    public class TwoArgsStrategy : IStrategy
    {
        private readonly Dictionary<string, Func<int, int, int>> _operationFunction;

        public TwoArgsStrategy()
        {
            _operationFunction = new Dictionary<string, Func<int, int, int>>
            {
                ["+"] = (fst, snd) => fst + snd,
                ["-"] = (fst, snd) => fst - snd,
                ["*"] = (fst, snd) => fst * snd,
                ["/"] = (fst, snd) => Division(fst, snd)
            };
        }

        private static int Division(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }

        public int Compute(string op, Stack<int> stack)
        {
            return _operationFunction[op](stack.Pop(), stack.Pop());
        }
    }
}