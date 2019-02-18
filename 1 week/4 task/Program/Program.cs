using System;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the size(odd) of matrix: ");
            int size = int.Parse(Console.ReadLine());
            if (size % 2 == 0)
            {
                Console.WriteLine("Size should be an odd number");
                return;
            }

            Matrix matrix = new Matrix(size);
            matrix.Initialization();
            matrix.PrintMatrix();
            SpiralBypass(matrix);
        }

        static void SpiralBypass(Matrix matrix)
        {
            int delta = 1;
            int direction = 1;
            int size = matrix.size;
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
