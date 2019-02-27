using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter string  ");
            string str = Console.ReadLine();
            bool isCorrectInput = true;

            var stackArray = new StackArray();
            var stackList = new StackList();
            var caluclatorArray = new Calculator(stackArray);
            var calculatorList = new Calculator(stackList);

            int resultArray = caluclatorArray.Calculation(str, isCorrectInput);
            int resultList = calculatorList.Calculation(str, isCorrectInput);            

            if (!isCorrectInput)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Console.WriteLine(resultArray);
            Console.WriteLine(resultList);
        }
    }
}
