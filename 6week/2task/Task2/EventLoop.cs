using System;

namespace Task2
{
    public class EventLoop
    {
        public event Action LeftHandler, RightHandler, TopHandler, DownHandler;

        public EventLoop()
        {
            LeftHandler += Game.OnLeft;
            RightHandler += Game.OnRight;
            TopHandler += Game.OnTop;
            DownHandler += Game.OnDown;
        }

        public bool ProcessKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    LeftHandler?.Invoke();
                    break;
                case ConsoleKey.RightArrow:
                    RightHandler?.Invoke();
                    break;
                case ConsoleKey.UpArrow:
                    TopHandler?.Invoke();
                    break;
                case ConsoleKey.DownArrow:
                    DownHandler?.Invoke();
                    break;
                default:
                    return false;
            }
            return true;
        }

        public void Run(string fileName)
        {
            Game.Settings();
            Map.CreateMap(fileName);
            var hero = new Hero(Map.HeroStartPointLeft, Map.HeroStartPointTop);
            hero.MoveHeroOnTheMap();

            bool wantToPlay = true;
            while (wantToPlay)
            {
                var key = Console.ReadKey(true);
                Console.Write("\b ");
                wantToPlay = ProcessKey(key.Key);
                hero.MoveHeroOnTheMap();
            }
        }
    }
}
