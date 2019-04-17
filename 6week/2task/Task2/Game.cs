using System;

namespace Task2
{
    class Game
    {
        public static void OnLeft()
            => Hero.ChangeHeroCoordinates(-1, 0);

        public static void OnRight()
            => Hero.ChangeHeroCoordinates(1, 0);
        
        public static void OnTop()
            => Hero.ChangeHeroCoordinates(0, -1);

        public static void OnDown()
            => Hero.ChangeHeroCoordinates(0, 1);

        public static void Settings()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
