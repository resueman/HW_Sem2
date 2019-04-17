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
        public static int LeftPosition { get; private set; }
        public static int TopPosition { get; private set; }

        public Hero(int leftPosition, int topPosition)
        {
            LeftPosition = leftPosition;
            TopPosition = topPosition;
        } 

        public void MoveHeroOnTheMap()
        {
            Console.SetCursorPosition(LeftPosition, TopPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Appearance);
        }

        public static void ChangeHeroCoordinates(int deltaLeft, int deltaTop)
        {
            if (!IsCorrectPosition(LeftPosition + deltaLeft, TopPosition + deltaTop))
            {
                return;
            }            
            LeftPosition += deltaLeft;
            TopPosition += deltaTop;
        }

        private static bool IsCorrectPosition(int left, int top)
        {
            if (top < 0 || left < 0)
            {
                return false;
            }
            if (top >=  Map.IsBorder.GetLength(0) || left >= Map.IsBorder.GetLength(1))
            {
                return false;
            }
            if (Map.IsBorder[top, left])
            {
                return false;
            }
            return true;
        }
    }
}
