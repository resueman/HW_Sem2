using System;
using System.IO;

namespace Task2
{
    class Map
    {
        public static Matrix<bool> IsBorder { get; private set; } 
        public Map()
        {            
            StreamReader objectReader = new StreamReader("Map.txt");
            IsBorder = new Matrix<bool>();
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
                    IsBorder.SetValue(numberOfCurrentLine, i , buffer[i] != ' ');
                }
            }
            objectReader.Close();
            Console.WriteLine("\nUse arrows to control the hero");
            Console.WriteLine("Press any other key to exit the game\n");
        }
    }
}
