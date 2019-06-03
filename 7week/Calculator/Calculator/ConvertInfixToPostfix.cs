using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ConvertInfixToPostfix
    {
        private int Precedence(string operation)
        {
            if (operation == "+" || operation == "-")
            {
                return 2;
            }
            return 1;
        }

        private bool TopHasLowerPrecedence(Stack<string> stack, string operation)
            => Precedence(stack.Peek()) <= Precedence(operation);

        private bool IsOperand(string symbol)
            => int.TryParse(symbol, out int _);        

        private bool IsOperator(string symbol)
            => symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";

        public List<string> InfixToPostfix(List<string> infixExpression)
        {
            //BracketBalance.Check(infixExpression);
            var stack = new Stack<string>();
            var postfixExpression = new List<string>();

            foreach (var node in infixExpression)
            {
                if (IsOperand(node))
                {
                    postfixExpression.Add(node);
                }
                else if (node == "(")
                {
                    stack.Push(node);
                }
                else if (IsOperator(node))
                {
                    while (stack.Count != 0 && TopHasLowerPrecedence(stack, node) && node != "(")
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

