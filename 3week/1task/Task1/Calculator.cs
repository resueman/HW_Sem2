namespace Task1
{
    public class Calculator
    {
        private readonly IStack<int> stack;

        public Calculator(IStack<int> stack)
        {
            this.stack = stack;
        }

        private static int PerformingOperation(int number1, int number2, string operation)
        {
            if (operation == "/" && number2 == 0)
            {
                throw new DivisionByZeroException("Division by zero");
            }

            switch (operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    return number1 / number2;
                default:
                    return 0;
            }
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
                        stack.Push(PerformingOperation(number2, number1, singleString));
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
