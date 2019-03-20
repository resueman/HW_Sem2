namespace Task1
{
    public class Calculator
    {
        private IStack<int> stack;

        public Calculator(IStack<int> stack)
        {
            this.stack = stack;
        }

        private int PerformingOperation(int number1, int number2, char operation)
        {
            if(operation == '/' && number2 == 0)
            {
                throw new DivisionByZeroException("Division by zero");
            }
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
                    }
                    else
                    {
                        throw new NotPostfixFormException("Incorrect symbol");
                    }
                }
                int answer = stack.Pop();
                if (!stack.IsEmpty())
                {
                    throw new NotPostfixFormException("Stack isn't empty after calculation, not a postfix form");
                }
                return answer;
            }
            catch (StackIsEmptyException innerException)
            {
                throw new NotPostfixFormException("Incorrect expression", innerException);
            }
        }
    }
}
