using System;
using System.IO;
using System.Collections.Generic;

namespace Task2
{
    class Map
    {
        public static bool[,] IsBorder { get; private set; }
        public Map()
        {            
            StreamReader objectReader = new StreamReader("Map.txt");
            int numberOfLines = int.Parse(objectReader.ReadLine());
            int numberOfColumns = int.Parse(objectReader.ReadLine());
            IsBorder = new bool[numberOfLines, numberOfColumns];

            int numberOfCurrentLine = -1;
            while (true)
            {
                string buffer = objectReader.ReadLine();
                ++numberOfCurrentLine;
                if (buffer == null)
                {
                    break;
                }

                Console.WriteLine(buffer);
                for (int i = 0; i < buffer.Length; ++i)
                {
                    IsBorder[numberOfCurrentLine, i] = buffer[i] != ' ';
                }
            }
            objectReader.Close();
            Console.WriteLine("\nUse arrows to control the hero");
            Console.WriteLine("Press any other key to exit the game...");
        }
    }
}
