using System;

namespace Task2
{
    /// <summary>
    /// Describes actions performed by the hero in game
    /// Contains game settings(Cursor visibility, walls color)
    /// </summary>
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
