using System;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the size of matrix: ");
            int size = int.Parse(Console.ReadLine());
            int [,] matrix = CreateMatrix(size);
            PrintMatrix(matrix);
            SpiralBypass(matrix);
        }

        static void SpiralBypass(int[,] matrix)
        {
            int delta = 1;
            int direction = 1;
            int size = matrix.GetLength(0);
            int i = size / 2;
            int j = size / 2;
            Console.Write($"{matrix[i, j]}  ");

            while (delta < size)
            {
                for (int k = 0; k < delta; ++k)
                {
                    i -= direction;
                    Console.Write($"{matrix[i, j]}  ");// up/down
                }

                for (int k = 0; k < delta; ++k)
                {
                    j += direction;
                    Console.Write($"{matrix[i, j]}  ");// right/left
                }

                direction = -direction;
                ++delta;
            }

            for (int k = 0; k < delta - 1; ++k)
            {
                i -= direction;
                Console.Write($"{matrix[i, j]}  ");//last up
            }
        }

        static int[,] CreateMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = random.Next(0, 9);
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
