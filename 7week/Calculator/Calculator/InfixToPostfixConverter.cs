using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    class InfixToPostfixConverter
    {
        private static int Precedence(string operation)
        {
            if (operation == "+" || operation == "-")
            {
                return 2;
            }
            return 1;
        }

        private static bool TopHasLowerPrecedence(string top, string operation)
            => Precedence(top) <= Precedence(operation);

        private static bool IsOperand(string symbol)
            => double.TryParse(symbol, out double _);

        public static List<string> Convert(string infixExpression)
        {
            var stack = new Stack<string>();
            var postfixExpression = new List<string>();
            var regularExpression = new Regex(@"(?((\*-\d*)|(\+-\d*)|(\/-\d*)|(\--\d*))(-\d*)|([-+)*/(]))");
            string[] splitted = regularExpression.Split(infixExpression);
            foreach (var node in splitted)
            {
                if (IsOperand(node))
                {
                    postfixExpression.Add(node);
                }
                else if (node == "(")
                {
                    stack.Push(node);
                }
                else if (Validator.IsOperator(node))
                {
                    while (stack.Count != 0 && TopHasLowerPrecedence(stack.Peek(), node) && stack.Peek() != "(")
                    {
                        postfixExpression.Add(stack.Pop());
                    }
                    stack.Push(node);
                }
                else if (node == ")")
                {
                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        postfixExpression.Add(stack.Pop());
                    }
                    stack.Pop();
                }
            }
            while (stack.Count != 0)
            {
                postfixExpression.Add(stack.Pop());
            }
            return postfixExpression;
        }
    }
}
