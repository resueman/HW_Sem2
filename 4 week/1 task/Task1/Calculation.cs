using System;

namespace Task1
{
    class Calculation
    {
        internal static int PerformingOperation(string operation, Node left, Node right)
        {
            if (operation == "/" && right.Calculate() == 0)
            {
                throw new IncorrectInputException("Devide by zero");
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
