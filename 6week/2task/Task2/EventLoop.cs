using System;

namespace Task2
{
    class EventLoop
    {
        public event Action LeftHandler;
        public event Action RightHandler;
        public event Action TopHandler;
        public event Action DownHandler;
        public void Run()
        {
            Map.PrintMap();
            var hero = new Hero();

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
