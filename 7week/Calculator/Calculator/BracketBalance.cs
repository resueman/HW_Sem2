using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // most likely is an excessive class
    class BracketBalance
    {
        public bool IsBalance(string expression)
        {
            var stack = new Stack<char>();
            foreach (var symbol in expression)
            {
                if (symbol == '(')
                {
                    stack.Push(symbol);
                }
                if (symbol == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }
}
