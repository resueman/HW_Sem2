using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            if (Task.Test())
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine(";(");
            }

            Console.ReadKey();
        }
    }
}
