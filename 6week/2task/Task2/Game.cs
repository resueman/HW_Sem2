using System;

namespace Task2
{
    /// <summary>
    /// Describes actions performed by the hero in game
    /// </summary>
    public class Game
    {
        public readonly Hero hero;
        
        public Game(string fileName)
        {
            Map.CreateMap(fileName);
            hero = new Hero(Map.HeroStartPointLeft, Map.HeroStartPointTop);
        }

        public void OnLeft()
            => hero.ChangeHeroCoordinates(-1, 0);

        public void OnRight()
            => hero.ChangeHeroCoordinates(1, 0);

        public void OnTop()
            => hero.ChangeHeroCoordinates(0, -1);

        public void OnDown()
            => hero.ChangeHeroCoordinates(0, 1);
    }
}
