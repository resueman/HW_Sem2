using System.Collections.Generic;

namespace Task3
{
    class Calculator
    {
        private readonly Stack<int> stack;

        private static int PerformingOperation(int number2, int number1, char operation)
        {
            //division by zero
            switch (operation)
            {
                case '+':
                    return number2 + number1;
                case '-':
                    return number2 - number1;
                case '*':
                    return number2 * number1;
                case '/':
                    return number2 / number1;
            }
            return 0;
        }

        public int Calculation(List<string> expression)
        {
            foreach (string singleString in expression)
            {
                if (singleString == "+" || singleString == "-" || singleString == "*" || singleString == "/")
                {
                    int number1 = stack.Pop();
                    int number2 = stack.Pop();
                    char operation = char.Parse(singleString);
                    int resultOfOperation = PerformingOperation(number2, number1, operation);
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
                throw new NotPostfixFormException("Not a postfix form");
            }
            return answer;
        }
    }
}
