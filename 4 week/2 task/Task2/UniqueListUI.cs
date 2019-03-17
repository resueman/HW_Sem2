using System;

namespace Task2
{
    class UniqueListUI
    {
        static private void PrintOptions()
        {
            Console.WriteLine("Please, choose option:\n");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Add node");
            Console.WriteLine("2 - Delete node");
            Console.WriteLine("3 - Print list");
            Console.WriteLine("4 - Clear list");
            Console.WriteLine("5 - Clear screen\n");
        }

        public static void Interaction()
        {
            PrintOptions();
            var set = new Set<string>();
            int userChoice;
            do
            {
                Console.Write("Choice:  ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out userChoice))
                {
                    Console.WriteLine("Incorrect input");
                }
                Action(set, userChoice);
            }
            while (userChoice != 0);
        }
    }
}
