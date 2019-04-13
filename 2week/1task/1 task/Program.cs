using System;

namespace Task1
{
    static class Program
    {
        static void Main()
        {
            if (!Task.Test())
            {
                Console.Clear();
                Console.WriteLine("Tests not passed");
                return;
            }
            Console.Clear();
            Console.WriteLine("Tests passed successfully!");
            UserInteraction.Interaction();
        }
    }
}
