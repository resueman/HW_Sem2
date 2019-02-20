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
            matrix.SpiralBypass();
        }
    }
}
