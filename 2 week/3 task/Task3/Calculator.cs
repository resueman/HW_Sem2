namespace Task3
{
    class Calculator
    {
        private IStack stack;

        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        private int PerformingOperation(int number1, int number2, char operation)
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

        public int Calculation(string expression, bool isCorrectInput)
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
                    stack.Push(int.Parse(expression[i].ToString()));
                    continue;
                }
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    int number1 = stack.Pop(isCorrectInput);
                    int number2 = stack.Pop(isCorrectInput);
                    int resultOfOperation = PerformingOperation(number2, number1, expression[i]);
                    stack.Push(resultOfOperation);
                    continue;
                }
                isCorrectInput = false;
            }
            return stack.Pop(isCorrectInput);
        }
    }
}
