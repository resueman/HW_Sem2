using System;

namespace Task2
{
    public class Hero
    {
        public static char Appearance { get; private set; } = '@';
        public static int LeftPosition { get; private set; }
        public static int TopPosition { get; private set; }

        public Hero(int leftPosition, int topPosition)
        {
            LeftPosition = leftPosition;
            TopPosition = topPosition;
            Console.SetCursorPosition(LeftPosition, TopPosition);
            PrintHero();
        } 

        public void PrintHero()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Appearance);
        }

        private static bool IsCorrectPosition(int left, int top)
        {
            if (top < 0 || left < 0)
            {
                return false;
            }
            if (top >=  Map.IsBorder.GetLength(0)|| left >= Map.IsBorder.GetLength(1))
            {
                return false;
            }
            if (Map.IsBorder[top, left])
            {
                return false;
            }
            return true;
        }

        public static void ChangeHeroPosition(int deltaLeft, int deltaTop)
        {
            if (!IsCorrectPosition(LeftPosition + deltaLeft, TopPosition + deltaTop))
            {
                Console.SetCursorPosition(LeftPosition, TopPosition);
                return;
            }            
            LeftPosition += deltaLeft;
            TopPosition += deltaTop;
            Console.SetCursorPosition(LeftPosition, TopPosition);
        }
    }
}
