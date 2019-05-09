using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class BracketBalance
    {
        public static bool Check(List<string> input)
        {
            var stack = new Stack<string>();
            foreach (var symbol in input)
            {
                if (symbol == "(")
                {
                    stack.Push(symbol);
                }
                if (symbol == ")")
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
