using System;

namespace Program
{
    class Matrix
    {
        public static int size;
        public static int[,] matrix;

        public Matrix(int number)
        {
            size = number;
            matrix = new int [number, number];
        }

        public int[,] Initialization()
        {
            Random random = new Random();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    matrix[i, j] = random.Next(1, 9);
                }
            }
            return matrix;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SpiralBypass()
        {
            int delta = 1;
            int direction = 1;
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
    }
}
