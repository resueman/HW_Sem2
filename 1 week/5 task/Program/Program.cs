using System;

namespace Task5
{
    class Program
    {
        static void Main()
        {
            Console.Write("Number of lines:   ");
            int lines = int.Parse(Console.ReadLine());
            Console.Write("Number of columns:   ");
            int columns = int.Parse(Console.ReadLine());
            if (lines < 1 || columns < 1)
            {
                Console.WriteLine("Incorrect input :(");
                return;
            }
            var matrix = new Matrix(lines, columns);
            Console.WriteLine("Initial matrix:");
            matrix.Initialization();
            matrix.PrintMatrix();
            Console.WriteLine("Result matrix:");
            matrix.GetResultMatrix();
            matrix.PrintMatrix();
        }
    }
}
