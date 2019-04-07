using System;

namespace Task2
{
    class Hero
    {
        private static char Appearance { get; set; } = '@';
        private static int Left { get; set; } = 1;
        private static int Top { get; set; } = 1;

        public Hero()
        {
            SetInitialHeroPosition();
        }
        public void SetInitialHeroPosition()
        {
            Console.SetCursorPosition(Left, Top);
            PrintHero();
        }
        public static void ChangeHeroPosition(int diffLeft, int diffTop)
        {
            Left += diffLeft;
            Top += diffTop;
            Console.SetCursorPosition(Left, Top);
        }
        public void PrintHero()
        {
            Console.Write(Appearance);
        }
    }
}
