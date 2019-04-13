using System;

namespace Task1
{
    static class UserInteraction
    {
        static private void PrintOptions()
        {
            Console.WriteLine("Please, choose option:\n");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Add element");
            Console.WriteLine("2 - Delete element");
            Console.WriteLine("3 - Get the number of elements");
            Console.WriteLine("4 - Check if the list is empty");
            Console.WriteLine("5 - Get value of element by its position");
            Console.WriteLine("6 - Set value of element by its position");
            Console.WriteLine("7 - Print List");
            Console.WriteLine("8 - Clear List");
            Console.WriteLine("9 - Clear screen\n");
        }

        static private void Action(List list, int choice)
        {
            switch (choice)
            {
                case 0:
                        break;
                case 1:
                    {
                        Console.Write("Enter the value of element:  ");
                        int value = int.Parse(Console.ReadLine());
                        Console.Write("Enter the position of element:  ");
                        int position = int.Parse(Console.ReadLine());
                        list.AddNode(value, position);
                        Console.WriteLine();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter the position of element to delete:  ");
                        int position = int.Parse(Console.ReadLine());
                        list.DeleteNode(position);
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    Console.WriteLine($"Length of list:  {list.Length}\n");
                    break;
                case 4:
                    {
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("List is empty\n");
                            break;
                        }
                        Console.WriteLine("List isn't empty\n");
                        break;
                    }
                case 5:
                    {
                        Console.Write("Enter the position of element:  ");
                        int position = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Value:  {list.GetValue(position)}");
                        Console.WriteLine();
                        break;
                    }
                case 6:
                    {
                        Console.Write("Enter the value of element:  ");
                        int value = int.Parse(Console.ReadLine());
                        Console.Write("Enter the position of element:  ");
                        int position = int.Parse(Console.ReadLine());
                        list.SetValue(value, position);
                        Console.WriteLine();
                        break;
                    }
                case 7:
                    {
                        string result = list.GetStringOfListElements();
                        if (result == "List is empty\n")
                        {
                            Console.WriteLine(result);
                            break;
                        }
                        Console.WriteLine($"Elements:  {result}\n");
                        break;
                    }
                case 8:
                    list.Clear();
                    Console.WriteLine();
                    break;
                case 9:
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
            int userChoice;
            var list = new List();
            do
            {
                Console.Write("Choice:  ");
                userChoice = int.Parse(Console.ReadLine());
                Action(list, userChoice);
            }
            while (userChoice != 0);
        }
    }
}
