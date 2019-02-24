using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            if (!Task.Test())
            {
                Console.WriteLine("Tests not passed");
                return;
            }
            Console.WriteLine("Tests passed successfully!");
            UserInteraction.Interaction();
        }
    }
}
