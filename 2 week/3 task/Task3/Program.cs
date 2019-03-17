using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            IStack stack = GetStackType();
            if (stack == null)
            {
                return;
            }
            var calculator = new Calculator(stack);
            Console.WriteLine("Enter the postfix expression separating the numbers and signs of the operations by spaces");
            Console.Write("Expression:  ");
            string expression = Console.ReadLine();
            try
            {
                Console.WriteLine(calculator.Calculation(expression));
            }            
            catch (StackIsEmptyException exception)
            {
                Console.WriteLine(exception.Message);
                if(exception.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", exception.InnerException.Message);
                }
            }
            catch (NotPostfixFormException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }

        private static IStack GetStackType()
        {
            Console.WriteLine("Choose type of stack:");
            Console.WriteLine("1 - list");
            Console.WriteLine("2 - array");
            Console.Write("Your choice:  ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    return new StackList();
                case "2":
                    return new StackArray();
                default:
                    Console.WriteLine("No such option");
                    return null;
            }
        }
    }
}
