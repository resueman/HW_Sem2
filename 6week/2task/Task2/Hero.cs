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

        /// <summary>
        /// Print hero on map
        /// </summary>
        public void PrintHeroOnMap()
        {
            Console.SetCursorPosition(LeftPosition, TopPosition);
            Console.Write(Appearance);
        }

        /// <summary>
        /// Change hero coordinates
        /// </summary>
        /// <param name="deltaLeft">Number of units to shift left or right</param>
        /// <param name="deltaTop">Number of units to shift up or down</param>
        public void ChangeHeroCoordinates(int deltaLeft, int deltaTop)
        {
            LeftPosition += deltaLeft;
            TopPosition += deltaTop;
        }
    }
}
