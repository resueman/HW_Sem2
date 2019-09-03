using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    /// <summary>
    /// Class for converting infix arithmetic expression to postfix form 
    /// </summary>
    public static class InfixToPostfixConverter
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

        /// <summary>
        /// Split expression on operands, operators and brackets
        /// </summary>
        /// <param name="infixExpression">Infix expression</param>
        /// <returns>Splitted infix expression</returns>
        private static List<string> Split(string infixExpression)
        {
            var regularExpression = new Regex(@"(?<![\)\d])\-\d+(\,)?\d*|\d+(\,)?\d*|[-+*/()]");
            var matches = regularExpression.Matches(infixExpression);
            var expression = new List<string>();
            foreach (Match match in matches)
            {
                expression.Add(match.Value);
            }
            return expression;
        }

        /// <summary>
        /// Covert infix arithmetic expression to postfix
        /// </summary>
        /// <param name="infixExpression">Infix expression</param>
        /// <returns>Postfix expression</returns>
        public static List<string> Convert(string infixExpression)
        {
            var stack = new Stack<string>();
            var postfixExpression = new List<string>();
            var expression = Split(infixExpression);
                  
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
                else if (Validators.IsOperator(unit))
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
