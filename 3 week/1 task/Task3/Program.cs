using System;

namespace Task3
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the line separating the numbers and signs of the operations by spaces");
            Console.Write("Expression:  ");
            string expression = Console.ReadLine();
            bool isCorrectInput = true;

            var stackArray = new StackArray();
            var stackList = new StackList();
            var caluclatorArray = new Calculator(stackArray);
            var calculatorList = new Calculator(stackList);

            int resultArray = caluclatorArray.Calculation(expression, ref isCorrectInput);
            int resultList = calculatorList.Calculation(expression, ref isCorrectInput);            

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
