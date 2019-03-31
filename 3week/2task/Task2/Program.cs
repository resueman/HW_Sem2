using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            try
            {
                UserInteraction.Interaction();
            }
            catch (IncorrectInputException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
