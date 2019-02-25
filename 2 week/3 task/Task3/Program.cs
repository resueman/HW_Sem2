using System;

namespace Task3
{
    class Program
    {
        private readonly IStack<string> stack;

        public Program(IStack<string> stack)
        {
            this.stack = stack;
        }

        int PerformingOperation(int number1, int number2, char operation)
        {
            int result = 0;
            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;
                case '/':
                    result = number1 / number2;
                    break;
            }
            return result;
        }

        static int Calculation(string str)
        {

        }

        static void Main()
        {
            Console.WriteLine("Enter string  ");
            string str = Console.ReadLine();
            Console.WriteLine(Calculation(str));
        }
    }
}
