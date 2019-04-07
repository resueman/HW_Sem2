using System;
using System.IO;
using System.Collections.Generic;

namespace Task2
{
    class Map
    {
        public static Matrix<bool> IsBorder { get; private set; }
        public Map()
        {
            IsBorder = new Matrix<bool>();
            StreamReader objectReader = new StreamReader("Map.txt");
            int numberOfCurrentLine = -1;

            while (true)
            {
                string buffer = objectReader.ReadLine();
                if (buffer == null)
                {
                    break;
                }

                Console.WriteLine(buffer);
                ++numberOfCurrentLine;
                for (int i = 0; i < buffer.Length; ++i)
                {
                    if (buffer[i] == ' ')
                    {
                        IsBorder.SetValue(numberOfCurrentLine, i, false);
                    }
                    else
                    {
                        IsBorder.SetValue(numberOfCurrentLine, i, true);
                    }
                }
            }
            objectReader.Close();
            Console.WriteLine("\nUse arrows to control the hero");
            Console.WriteLine("Press any other key to exit the game...");
        }
    }
}
