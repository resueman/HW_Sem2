using System;

namespace Program
{
    class Matrix
    {
        public int size;
        public int[,] matrix;

        public Matrix(int size)
        {
            this.size = size;
            matrix = new int [this.size, this.size];
        }

        public int this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
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
    }
}
