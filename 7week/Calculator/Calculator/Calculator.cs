using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {
        private readonly Stack<int> stack;

        private static int PerformingOperation(int number2, int number1, string operation)
        {
            if (operation == "/" && number1 == 0)
            {
                throw new DivisionByZeroException("Expression contains division by zero");
            }

            if (operation == "+")
            {
                return number2 + number1;
            }
            else if (operation == "-")
            {
                return number2 - number1;
            }
            else if (operation == "*")
            {
                return number2 * number1;
            }
            return number2 / number1;
        }

        public int Calculation(List<string> expression)
        {
            foreach (string singleString in expression)
            {
                if (singleString == "+" || singleString == "-" || singleString == "*" || singleString == "/")
                {
                    int number1 = stack.Pop();
                    int number2 = stack.Pop();
                    int resultOfOperation = PerformingOperation(number2, number1, singleString);
                    stack.Push(resultOfOperation);
                    continue;
                }
                else
                {
                    stack.Push(int.Parse(singleString));
                    continue;
                }
            }
            int answer = stack.Pop();
            if (stack.Count != 0)
            {
                throw new IncorrectInfixExpressionException("Incorrect input");
            }
            return answer;
        }
    }
}
