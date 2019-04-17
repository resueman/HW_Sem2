using System;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Class responsible for reading map from a file
    /// for determining original hero coordinates, 
    /// for determining and saving coordinates of the walls 
    /// for keeping size of area, possible to play on 
    /// and changing it depending on number and location of walls
    /// </summary>
    public class Map
    {
        public const int resizeMapIndex = 10;
        public static int HeroStartPointLeft { get; private set; }
        public static int HeroStartPointTop { get; private set; }
        public static bool[,] IsBorder { get; private set; }

        private static void ResizeMap(bool addLines)
        {
            bool[,] newMatrix;
            if (addLines)
            {
                newMatrix = new bool[resizeMapIndex + IsBorder.GetLength(0), IsBorder.GetLength(1)];
            }
            else
            {
                newMatrix = new bool[IsBorder.GetLength(0), resizeMapIndex + IsBorder.GetLength(1)];
            }
            for (int i = 0; i < IsBorder.GetLength(0); ++i)
            {
                for (int j = 0; j < IsBorder.GetLength(1); ++j)
                {
                    newMatrix[i, j] = IsBorder[i, j];
                }
            }
            IsBorder = newMatrix;
        }

        public static void CreateMap(string fileName)
        {
            StreamReader objectReader = new StreamReader(fileName);

            IsBorder = new bool[,] { };
            int currentLine = -1;
            bool heroFound = false;
            while (true)
            {
                string buffer = objectReader.ReadLine();
                ++currentLine;
                if (buffer == null)
                {
                    break;
                }
                if (currentLine >= IsBorder.GetLength(0))
                {
                    ResizeMap(true);
                }
                for (int i = 0; i < buffer.Length; ++i)
                {
                    if (i >= IsBorder.GetLength(1))
                    {
                        ResizeMap(false);
                    }
                    if (buffer[i] == Hero.Appearance)
                    {
                        if (heroFound)
                        {
                            throw new IncorrectMapException("Borders look like hero");
                        }
                        heroFound = true;
                        HeroStartPointLeft = i;
                        HeroStartPointTop = currentLine;
                        IsBorder[currentLine, i] = false;
                        continue;
                    }
                    IsBorder[currentLine, i] = buffer[i] != ' ';
                }
                Console.WriteLine(buffer);
            }
            objectReader.Close();
            if (!heroFound)
            {
                throw new IncorrectMapException("Incorrect map, there is no hero start position");
            }
        }
    }
}
