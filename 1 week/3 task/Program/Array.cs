using System;

namespace Program
{
    class Array
    {
        public static int[] CreateArray(int size)
        {
            int[] newArray = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; ++i)
            {
                newArray[i] = random.Next(-15, 15);
            }
            return newArray;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
