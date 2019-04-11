namespace Task1
{
    public class Calculator
    {
        private IStack<int> stack;

        public Calculator(IStack<int> stack)
        {
            this.stack = stack;
        }

        private static int PerformingOperation(int number2, int number1, string operation)
        { 
            if (operation == "/" && number1 == 0)
            {
                throw new DivisionByZeroException("Division by zero");
            }
            int result = 0;
            switch (operation)
            {
                case "+":
                    result = number2 + number1;
                    break;
                case "-":
                    result = number2 - number1;
                    break;
                case "*":
                    result = number2 * number1;
                    break;
                case "/":
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

                foreach (string symbol in expressionWithoutGaps)
                {
                    if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/")
                    {
                        int number1 = stack.Pop();
                        int number2 = stack.Pop();
                        int resultOfOperation = PerformingOperation(number2, number1, symbol);
                        stack.Push(resultOfOperation);
                        continue;
                    }
                    if (int.TryParse(symbol, out int number))
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
                throw new NotPostfixFormException("Incorrect expression", innerException);
            }
        }
    }
}
