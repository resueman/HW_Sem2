using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            var stackArray = new StackArray(8);//////////improve StackArray
            var listArray = new StackList();
            ///finish interface

            Console.WriteLine("Enter string  ");
            string str = Console.ReadLine();
            bool isCorrectInput = true;
            int resultOfCalculation = Calculator.Calculation(str, isCorrectInput);
            if (!isCorrectInput)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Console.WriteLine(resultOfCalculation);
        }
    }
}
