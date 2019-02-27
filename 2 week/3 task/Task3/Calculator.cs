using System;

namespace Task3
{
    class Calculator
    {
        private static int PerformingOperation(int number1, int number2, char operation)
        {
            int result = 0;
            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;
                case '/':
                    result = number1 / number2;
                    break;
            }
            return result;
        }

        public static int Calculation(string expression, bool isCorrectInput)
        {
            for (int i = 0; i < expression.Length; ++i)
            {
                if (!isCorrectInput)
                {
                    return -666;
                }
                if (expression[i] == ' ')
                {
                    continue;
                }
                if (char.IsDigit(expression[i]))
                {
                    stack.Push(Convert.ToInt32(expression[i]));
                    continue;
                }
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    int number1 = stack.Pop(isCorrectInput);
                    int number2 = stack.Pop(isCorrectInput);
                    int resultOfOperation = PerformingOperation(number1, number2, expression[i]);
                    stack.Push(resultOfOperation);
                    continue;
                }
                isCorrectInput = false;
            }
            return stack.Pop(isCorrectInput);
        }
    }
}
