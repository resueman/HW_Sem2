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

        static int CalculateFibonacci(int position)
        {
            int current = 1;
            int next = 1;
            int answer = 1;

            for(int i = 2; i < position; ++i)
            {
                answer = current + next;
                current = next;
                next = answer;
            }
            return answer;
        }
    }
}
