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
            Console.SetCursorPosition(Left, Top);
            PrintHero();
        }
        public void PrintHero()
        {
            Console.Write(Appearance);
        }
        public static void ChangeHeroPosition(int diffLeft, int diffTop)
        {
            if(Map.IsBorder[Left + diffLeft, Top + diffTop])
            {
                Console.SetCursorPosition(Left, Top);
                return;
            }
            Left += diffLeft;
            Top += diffTop;
            Console.SetCursorPosition(Left, Top);
        }
    }
}
