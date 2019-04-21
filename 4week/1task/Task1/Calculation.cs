namespace Task1
{
    /// <summary>
    /// Performs calculation of expression
    /// </summary>
    class Calculation
    {
        internal static int PerformingOperation(string operation, Node left, Node right)
        {
            if (operation == "/" && right.Calculate() == 0)
            {
                throw new DivisionByZeroException("Devide by zero");
            }

            switch (operation)
            {
                case "+":
                    return left.Calculate() + right.Calculate();
                case "-":
                    return left.Calculate() - right.Calculate();
                case "*":
                    return left.Calculate() * right.Calculate();
                case "/":
                    return left.Calculate() / right.Calculate();
                default:
                    throw new IncorrectInputException("Unexpected symbol");
            }
        }
    }
}
