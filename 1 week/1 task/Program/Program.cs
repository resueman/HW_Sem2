using System;

namespace FirstTask
{
    class Program
    {
        static void Main()
        {
            InteractiveFactorial();
            InteractiveFibonacci();
        }

        static void InteractiveFactorial()
        {
            Console.Write("Let's calculate the factorial of a number:   ");
            int numberFactorial = int.Parse(Console.ReadLine());
            if (numberFactorial < 0)
            {
                Console.WriteLine("Incorrect input");
            }
            else
            {
                Console.WriteLine($"Answer:   {CalculateFactorial(numberFactorial)}");
            }
        }

        static int CalculateFactorial(int number)
            => number <= 1 ? 1 : number * CalculateFactorial(number - 1);

        static void InteractiveFibonacci()
        {
            Console.Write("Let's calculate Fibonacci number:   ");
            int numberFibonacci = int.Parse(Console.ReadLine());
            if (numberFibonacci < 1)
            {
                Console.WriteLine("Incorrect input");
            }
            else
            {
                Console.WriteLine($"Answer:   {CalculateFibonacci(numberFibonacci)}");
            }
        }

        static int CalculateFibonacci(int number)
        {
            if (number <= 0)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }
            return CalculateFibonacci(number - 1) + CalculateFibonacci(number - 2);
        }
    }
}
