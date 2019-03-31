using System;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of elements:  ");
            int number = int.Parse(Console.ReadLine());
            int[] array = Array.CreateArray(number);
            Console.WriteLine("Original Array:");
            Array.PrintArray(array);
            Console.WriteLine("Result array:");
            Sort.QuickSort(array, 0, number - 1);
            Array.PrintArray(array);
        }
    }
}
