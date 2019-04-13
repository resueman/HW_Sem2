using System;

namespace Task2
{
    /// <summary>
    /// Class which gets user choice and processes it
    /// </summary>
    static class UniqueListUI
    {
        private static void PrintOptions()
        {
            Console.WriteLine("Please, choose option:\n");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Add node");
            Console.WriteLine("2 - Delete node");
            Console.WriteLine("3 - Print list");
            Console.WriteLine("4 - Clear list");
            Console.WriteLine("5 - Clear screen\n");
        }

        private static void Action(UniqueList<string> list, int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    {
                        Console.Write("Enter value of new element: ");
                        string value = Console.ReadLine();
                        list.AddNode(value);
                        Console.WriteLine("Success!\n");
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter value of element to delete: ");
                        string value = Console.ReadLine();
                        list.DeleteNode(value);
                        Console.WriteLine("Success!\n");
                        break;
                    }
                case 3:
                    list.Print();
                    break;
                case 4:
                    list.Clear();
                    Console.WriteLine("Success!\n");
                    break;
                case 5:
                    Console.Clear();
                    PrintOptions();
                    break;
                default:
                    Console.WriteLine("No such option");
                    break;
            }
        }

        public static void Interaction()
        {
            PrintOptions();
            var uniqueList = new UniqueList<string>();
            int userChoice;
            do
            {
                Console.Write("Choice:  ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out userChoice))
                {
                    Console.WriteLine("Incorrect input");
                }
                Action(uniqueList, userChoice);
            }
            while (userChoice != 0);
        }
    }
}
