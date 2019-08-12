using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PostfixCalculator
    {
        private double PerformingOperation(double operand1, double operand2, string operation)
        {
            if (operation == "/" && operand2 == 0)
            {
                throw new ArgumentOutOfRangeException("Division by zero");
            }
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
            }
            return result;
        }

        private bool IsOperator(string symbol)
        {
            return symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
        }

        public double CalculateResult(List<string> expression)
        {
            double expressionValue = 0;
            var stack = new Stack<double>();

            foreach (var unit in expression)
            {
                if (double.TryParse(unit, out double operand))
                {
                    stack.Push(operand);
                }
                else if (IsOperator(unit))
                {
                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    var intermediateValue = PerformingOperation(operand1, operand2, unit);
                    stack.Push(intermediateValue);
                }
                else
                {
                    throw new ArgumentException("Unexpected symbol");
                }
            }
            expressionValue = stack.Pop();
            if (stack.Count != 0)
            {
                throw new ArgumentException("Input string is not a postfix form");
            }
            return expressionValue;
        }
    }
}
