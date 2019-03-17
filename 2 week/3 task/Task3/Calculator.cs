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
            catch(StackIsEmptyException innerException)
            {
                throw new StackIsEmptyException("Stack is empty", innerException);
            }
        }
    }
}
