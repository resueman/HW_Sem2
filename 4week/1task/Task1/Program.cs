using System;

namespace Task1
{
    /// <summary>
    /// Class to interact with user
    /// </summary>
    static class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter expression");
                string line = Console.ReadLine();
                var tree = new Tree(line);
                Console.WriteLine("Expression:");
                tree.PrintTree();
                Console.WriteLine($"Result of calculation:  {tree.CalculateTree()}");
                Console.ReadKey();
            }
            catch (IncorrectInputException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
