using System;
using System.IO;

namespace Task2
{
    class Map
    {
        public static Matrix<bool> IsBorder { get; private set; }
        public Map()
        {
            try
            {
                StreamReader objectReader = new StreamReader("Map.txt");
                IsBorder = new Matrix<bool>();
                int currentLine = -1;
                while (true)
                {
                    string buffer = objectReader.ReadLine();
                    ++currentLine;
                    if (buffer == null)
                    {
                        break;
                    }
                    for (int i = 0; i < buffer.Length; ++i)
                    {
                        IsBorder.SetValue(currentLine, i, buffer[i] != ' ');
                    }
                    Console.WriteLine(buffer);
                }
                objectReader.Close();
            }
            catch (FileNotFoundException inner)
            {
                throw new MapNotFoundException("File with map not found", inner);
            }
        }
    }
}
