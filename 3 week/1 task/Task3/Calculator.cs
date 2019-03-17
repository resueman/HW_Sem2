namespace Task3
{
    public class Calculator
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

        public int Calculation(string expression, ref bool isCorrectInput)
        {
            string[] expressionWithoutGaps;
            char[] splitchar = { ' ' };
            expressionWithoutGaps = expression.Split(splitchar);

            foreach(string singleString in expressionWithoutGaps)
            {                            
                if (singleString == "+" || singleString == "-" || singleString == "*" || singleString == "/")
                {
                    int number1 = stack.Pop(ref isCorrectInput);
                    int number2 = stack.Pop(ref isCorrectInput);
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
                isCorrectInput = false;
                return -666;
            }
            return stack.Pop(ref isCorrectInput);
        }
    }
}
