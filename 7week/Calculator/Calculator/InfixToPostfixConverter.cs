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

            var regularExpression = new Regex(@"(?<![\)\d])\-\d+(\,)?\d*|\d+(\,)?\d*|[-+*/()]");
            var matches = regularExpression.Matches(infixExpression);
            var expression = new List<string>();
            foreach(Match match in matches)
            {
                expression.Add(match.Value);
            }
                  
            foreach (var unit in expression)
            {
                if (IsOperand(unit))
                {
                    postfixExpression.Add(unit);
                }
                else if (unit == "(")
                {
                    stack.Push(unit);
                }
                else if (Validator.IsOperator(unit))
                {
                    while (stack.Count != 0 && TopHasLowerPrecedence(stack.Peek(), unit) && stack.Peek() != "(")
                    {
                        postfixExpression.Add(stack.Pop());
                    }
                    stack.Push(unit);
                }
                else if (unit == ")")
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
