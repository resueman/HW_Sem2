using System;
using System.IO;

namespace Task2
{
    class Map
    {
        public static void PrintMap()
        {
            StreamReader objectReader = new StreamReader("Map.txt");
            string buffer = "";
            while (buffer != null)
            {
                buffer = objectReader.ReadLine();
                if (buffer != null)
                {
                    Console.WriteLine(buffer);
                }
            }
            objectReader.Close();
            Console.WriteLine("\nPress any key except arrows to exit the game...");
        }
    }
}
