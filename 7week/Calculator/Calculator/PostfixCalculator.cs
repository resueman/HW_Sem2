using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Class, which contains method for calculating postfix expression value 
    /// </summary>
    public static class PostfixCalculator
    {
        private static double PerformingOperation(double operand1, double operand2, string operation)
        {
            if (operation == "/" && operand2 == 0)
            {
                throw new DivideByZeroException();
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

        /// <summary>
        /// Calculates postfix expression value
        /// </summary>
        /// <param name="expression">Arithmetic expression</param>
        /// <returns>Expression value</returns>
        public static double Calculate(List<string> expression)
        {
            try
            {
                var stack = new Stack<double>();

                foreach (var unit in expression)
                {
                    if (double.TryParse(unit, out double operand))
                    {
                        stack.Push(operand);
                    }
                    else if (Validators.IsOperator(unit))
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
                var expressionValue = stack.Pop();
                if (stack.Count != 0)
                {
                    throw new ArgumentException("Input string is not a postfix form");
                }
                return expressionValue;
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("Input string is not a postfix form");
            }
        }
    }
}
