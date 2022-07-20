using System;

namespace RPNCalulator
{
    public class RPN
    {
        private Stack<int> _operators;
        private readonly Context context = new();


        public int EvalRPN(string input)
        {
            _operators = new Stack<int>();
            var splitInput = input.Split(' ');
            foreach (var op in splitInput)
                if (IsNumber(op))
                {
                    _operators.Push(int.Parse(op));
                }
                else if (IsBinaryNumber(op))
                {
                    _operators.Push(ConvertBinary(op));
                }
                else if (IsDecimalNumber(op))
                {
                    _operators.Push(ConvertDecimal(op));
                }
                else
                {
                    var temp = op;
                    context.SetStrategy(temp);
                    var result = context.ExecuteOperation(temp, _operators);
                    _operators.Push(result);
                }

            var resultPop = _operators.Pop();
            if (_operators.IsEmpty) return resultPop;
            throw new InvalidOperationException();
        }

        private bool IsNumber(string input)
        {
            return int.TryParse(input, out _);
        }

        private bool IsDecimalNumber(string input)
        {
            return input.StartsWith('D');
        }

        private bool IsBinaryNumber(string input)
        {
            return input.StartsWith('B');
        }

        private int ConvertDecimal(string input)
        {
            var a = input.TrimStart('D');
            if (IsNumber(a)) return int.Parse(a);
            throw new ArgumentException();
        }

        private int ConvertBinary(string input)
        {
            var a = input.TrimStart('B');
            if (IsNumber(a))
            {
                var b = Convert.ToInt32(a, 2);
                return b;
            }

            throw new ArgumentException();
        }
    }
}