using System;

namespace Task2
{
    /// <summary>
    /// Class responsible for creating hero, 
    /// for changing its coordinates, 
    /// for moving the hero on the console screen 
    /// </summary>
    public class Hero
    {
        public static char Appearance { get; private set; } = '@';
        public int LeftPosition { get; private set; }
        public int TopPosition { get; private set; }

        public Hero(int leftPosition, int topPosition)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LeftPosition = leftPosition;
            TopPosition = topPosition;
            PrintHeroOnMap();
        }

        public void PrintHeroOnMap()
        {
            Console.SetCursorPosition(LeftPosition, TopPosition);
            Console.Write(Appearance);
        }

        public void ChangeHeroCoordinates(int deltaLeft, int deltaTop)
        {
            LeftPosition += deltaLeft;
            TopPosition += deltaTop;
        }
    }
}
