using System;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the size(odd) of matrix: ");
            int size = int.Parse(Console.ReadLine());
            if (size > 0 && size % 2 == 0)
            {
                Console.WriteLine("Size should be an odd number above zero");
                return;
            }
            
            var matrix = new Matrix(size);
            matrix.PrintMatrix();
            matrix.SpiralBypass();
        }
    }
}
