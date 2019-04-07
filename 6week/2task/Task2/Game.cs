using System;

namespace Task2
{
    class Game
    {
        public static void OnLeft()
        {
            Hero.ChangeHeroPosition(-1, 0);
        }
        public static void OnRight()
        {
            Hero.ChangeHeroPosition(1, 0);
        }
        public static void OnTop()
        {
            Hero.ChangeHeroPosition(0, -1);
        }
        public static void OnDown()
        {
            Hero.ChangeHeroPosition(0, 1);
        }
    }
}
