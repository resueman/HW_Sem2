﻿using System;

namespace Task2
{
    /// <summary>
    /// Static class with functions to work with user
    /// Functions, which print options, wait for user choice, react for it
    /// </summary>
    static class UserInteraction
    {
        /// <summary>
        /// Prints hash table options
        /// </summary>
        static private void PrintHashTableOptions()
        {
            Console.WriteLine("\nPlease, choose option:\n");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Check if the key exists");
            Console.WriteLine("2 - Add key");
            Console.WriteLine("3 - Delete key");
            Console.WriteLine("4 - Print set");
            Console.WriteLine("5 - Clear screen\n");
        }

        /// <summary>
        /// Prints types of hash functions
        /// </summary>
        static private void PrintTypesOfHashFunction()
        {
            Console.WriteLine("Please, choose hash function:\n");
            Console.WriteLine("1 - NoName hash function");
            Console.WriteLine("2 - Jenkins hash function");
            Console.WriteLine("3 - FNV hash function\n");
        }

        /// <summary>
        /// Function which processes the received data(user choice) 
        /// And creates instance of desired hash function
        /// </summary>
        /// <returns>Type of data stored in set</returns>
        static private IHashFunction<string> ChooseHashFunction()
        {
            PrintTypesOfHashFunction();
            Console.Write("Your choice: ");
            string stringTypeOfHash = Console.ReadLine();
            if (!int.TryParse(stringTypeOfHash, out int intTypeOfHash))
            {
                throw new IncorrectInputException("Incorrect input, enter number, please");
            }

            switch (intTypeOfHash)
            {
                case 1:
                    return new NoNameHashFunction<string>();
                case 2:
                    return new JenkinsHashFunction<string>();
                case 3:
                    return new FNVHashFunction<string>();
                default:
                    throw new IncorrectInputException("No such hash function");
            }
        }

        /// <summary>
        /// Processes user choice
        /// </summary>
        /// <param name="set">Hash table</param>
        /// <param name="choice">User choice</param>
        static private void PerformUserDesire(HashTable<string> set, int choice)
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
                    PrintHashTableOptions();
                    break;
                default:
                    Console.WriteLine("No such option\n");
                    break;
            }
        }

        /// <summary>
        /// Gets and processes user choice
        /// </summary>
        static public void Interaction()
        {
            var hashTable = new HashTable<string>(ChooseHashFunction());
            PrintHashTableOptions();
            int userChoice = 0;
            do
            {
                Console.Write("Choice:  ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out userChoice))
                {
                    throw new IncorrectInputException("Incorrect input, enter number, please");
                }
                PerformUserDesire(hashTable, userChoice);
            }
            while (userChoice != 0);
        }
    }
}
