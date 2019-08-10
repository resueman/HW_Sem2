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
            MoveHeroOnTheMap();
        }

        private void MoveHeroOnTheMap()
        {
            Console.SetCursorPosition(LeftPosition, TopPosition);
            Console.Write(Appearance);
        }

        public void ChangeHeroCoordinates(int deltaLeft, int deltaTop)
        {
            if (!IsCorrectPosition(LeftPosition + deltaLeft, TopPosition + deltaTop))
            {
                MoveHeroOnTheMap();
                return;
            }            
            LeftPosition += deltaLeft;
            TopPosition += deltaTop;
            MoveHeroOnTheMap();
        }

        private bool IsCorrectPosition(int left, int top)
        {
            if (top < 0 || left < 0)
            {
                return false;
            }
            if (top >=  Map.IsBorder.GetLength(0) || left >= Map.IsBorder.GetLength(1))
            {
                return false;
            }
            return !Map.IsBorder[top, left];
        }
    }
}
