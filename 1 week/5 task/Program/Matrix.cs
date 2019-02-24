using System;

namespace Task5
{
    class Matrix
    {
        readonly int[,] matrix;

        public Matrix(int lines, int columns)
        {
            matrix = new int[lines, columns];
        }

        public void Initialization()
        {
            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = random.Next(-20, 20);
                }
            }
        }

        public void GetResultMatrix()
        {
            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
            {
                int indexMin = i;
                for (int j = i + 1; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[0, j] < matrix[0, indexMin])
                    {
                        indexMin = j;
                    }
                }
                SwapColumns(matrix, i, indexMin);
            }
        }

        static void SwapColumns(int[,] matrix, int column1, int column2)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int buffer = matrix[i, column1];
                matrix[i, column1] = matrix[i, column2];
                matrix[i, column2] = buffer;
            }
        }

        public void PrintMatrix()
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
