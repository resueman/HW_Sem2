using System;

namespace Task2
{
    class UserInteraction
    {
        static private void PrintOptions()
        {
            Console.WriteLine("Please, choose option:\n");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Check if the key exists");
            Console.WriteLine("2 - Add key");
            Console.WriteLine("3 - Delete key");
            Console.WriteLine("4 - Print set");
            Console.WriteLine("5 - Clear screen\n");
        }

        static private void Action(HashTable<string> set, int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    {
                        Console.Write("Enter the key to find:  ");
                        string key = Console.ReadLine();
                        if (set.IsExist(key))
                        {
                            Console.WriteLine("Exists\n");
                            break;
                        }
                        Console.WriteLine("Doesn't exist\n");
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter the key to add:  ");
                        string key = Console.ReadLine();
                        if (set.AddToSet(key))
                        {
                            Console.WriteLine("Success!\n");
                            break;
                        }
                        Console.WriteLine("Such a key already exists\n");
                        break;
                    }
                case 3:
                    {
                        Console.Write("Enter the key to delete:  ");
                        string key = Console.ReadLine();
                        if (set.DeleteFromSet(key))
                        {
                            Console.WriteLine("Success!\n");
                            break;
                        }
                        Console.WriteLine("No such a key\n");
                        break;
                    }
                case 4:
                    set.PrintHashTable();
                    break;
                case 5:
                    Console.Clear();
                    PrintOptions();
                    break;
                default:
                    Console.WriteLine("No such option\n");
                    break;
            }
        }

        static public void Interaction()
        {
            PrintOptions();
            var hashTable = new HashTable<string>();
            int userChoice;
            do
            {
                Console.Write("Choice:  ");                
                string input = Console.ReadLine();
                if (!int.TryParse(input, out userChoice))
                {
                    Console.WriteLine("Incorrect input"); 
                }
                Action(hashTable, userChoice);
            }
            while (userChoice != 0);
        }
    }
}
