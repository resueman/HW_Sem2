using System;

namespace Task1
{
    class Program
    {
        private static void Main(string[] args)
        {
            IStack<int> stack = GetStackType();
            var calculator = new Calculator(stack);
            Console.WriteLine("\nSeparating numbers and signs of operations by spaces");
            Console.WriteLine("Enter the postfix expression, please\n");
            Console.Write("Expression:  ");
            string expression = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Console.WriteLine($"Result of calculation:  {calculator.Calculation(expression)}");
            }
            catch (NotPostfixFormException exception)
            {
                Console.WriteLine(exception.Message);
                if (exception.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", exception.InnerException.Message);
                }
            }
            catch (DivisionByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }

        private static IStack<int> GetStackType()
        {
            Console.WriteLine("Choose type of stack:");
            Console.WriteLine("1 - list");
            Console.WriteLine("2 - array\n");
            while (true)
            {
                Console.Write("Your choice:  ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return new StackList<int>();
                    case "2":
                        return new StackArray<int>();
                    default:
                        Console.WriteLine("No such option, try again\n");
                        break;
                }
            }
        }
    }
}
