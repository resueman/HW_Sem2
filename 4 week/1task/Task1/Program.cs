using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter expression");
            //string line = Console.ReadLine();
            string line = "( * ( + 1 1 ) 2 )";
            Tree tree = new Tree(line);
            Console.WriteLine("Expression:");
            tree.PrintTree();
            
            Console.WriteLine($"Result of calculation:  {tree.CalculateTree()}");
            Console.ReadKey();
        }
    }
}
