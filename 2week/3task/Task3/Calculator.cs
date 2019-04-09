namespace Task3
{
    class Calculator
    {
        private readonly IStack<int> stack;

        public Calculator(IStack<int> stack)
        {
            this.stack = stack;
        }

        private static int PerformingOperation(int number2, int number1,char operation)
        {
            int result = 0;
            switch (operation)
            {
                case '+':
                    result = number2 + number1;
                    break;
                case '-':
                    result = number2 - number1;
                    break;
                case '*':
                    result = number2 * number1;
                    break;
                case '/':
                    result = number2 / number1;
                    break;
            }
            return result;
        }

        public int Calculation(string expression)
        {
            try
            {
                string[] expressionWithoutGaps;
                char[] splitChar = { ' ' };
                expressionWithoutGaps = expression.Split(splitChar);

                foreach (string singleString in expressionWithoutGaps)
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
                    if (int.TryParse(singleString, out int number))
                    {
                        stack.Push(number);
                        continue;
                    }
                    else
                    {
                        throw new NotPostfixFormException("Incorrect symbol");
                    }
                }
                int answer = stack.Pop();
                if (!stack.IsEmpty())
                {
                    throw new NotPostfixFormException("Not a postfix form");
                }
                return answer;
            }
            catch (StackIsEmptyException innerException)
            {
                throw new StackIsEmptyException("Stack is empty", innerException);
            }
        }
    }
}
