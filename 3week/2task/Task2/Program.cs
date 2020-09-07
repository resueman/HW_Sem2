using System;

namespace Task2
{
    static class Program
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
