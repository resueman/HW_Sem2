using System;

namespace Program
{
    class Matrix
    {
        int[,] matrix;
        
        public Matrix(int number)
        {
            matrix = new int [number, number];
        }

        public int[,] Initialization()
        {
            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    matrix[i, j] = random.Next(1, 9);
                }
            }
            return matrix;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
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
            int i = matrix.GetLength(0) / 2;
            int j = matrix.GetLength(0) / 2;

            Console.Write($"{matrix[i, j]}  ");

            while (delta < matrix.GetLength(0))
            {
                for (int k = 0; k < delta; ++k)
                {
                    i -= direction;
                    Console.Write($"{matrix[i, j]}  "); //up/down
                }

                for (int k = 0; k < delta; ++k)
                {
                    j += direction;
                    Console.Write($"{matrix[i, j]}  "); //right/left
                }

                direction = -direction;
                ++delta;
            }

            for (int k = 0; k < delta - 1; ++k)
            {
                i -= direction;
                Console.Write($"{matrix[i, j]}  "); //last up
            }
        }
    }
}
