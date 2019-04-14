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

        public void Run()
        {
            Map.CreateMap("Map.txt");
            var hero = new Hero(Map.HeroStartPointLeft, Map.HeroStartPointTop);

            bool wantToPlay = true;
            while (wantToPlay)
            {
                var key = Console.ReadKey(true);
                Console.Write("\b ");
                switch (key.Key)
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
                        wantToPlay = false;
                        break;
                }
                hero.PrintHero();
            }
        }
    }
}
