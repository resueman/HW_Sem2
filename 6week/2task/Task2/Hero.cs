using System;
using System.Collections.Generic;

namespace Task2
{
    class Hero
    {
        private static char Appearance { get; set; } = '@';
        private static int LeftPosition { get; set; } = 1;
        private static int TopPosition { get; set; } = 1;

        public Hero()
        {
            Console.SetCursorPosition(LeftPosition, TopPosition);
            PrintHero();
        }
        public void PrintHero()
        {
            Console.Write(Appearance);
        }

        private static bool IsCorrectPosition(int left, int top)
        {
            if (top < Matrix<bool>.topBorder || left < Matrix<bool>.leftBorder)
            {
                return false;
            }
            if (top >= Matrix<bool>.MaxDownBorder || left >= Matrix<bool>.MaxRightBorder)
            {
                return false;
            }
            if (Map.IsBorder.GetValue(top, left))
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
