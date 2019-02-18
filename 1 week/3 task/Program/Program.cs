using System;

namespace Program
{
    class Program
    {
        static int[] CreateArray(int size)
        {
            Random random = new Random();
            int[] newArray = new int[size];
            for (int i = 0; i < size; ++i)
            {
                newArray[i] = random.Next(-15, 15);
            }
            return newArray;
        }

        static void PrintArray(int[] array)
        {
            foreach(int element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Console.Write("Enter the number of elements:  ");
            int number = int.Parse(Console.ReadLine());
            int[] array = CreateArray(number);
            Console.WriteLine("Original Array:");
            PrintArray(array);
            Console.WriteLine("Result array:");
            Sort.QuickSort(array, 0, number - 1);
            PrintArray(array);
        }
    }
}

