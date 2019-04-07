using System;

namespace Task2
{
    class EventLoop
    {
        public event Action LeftHandler, RightHandler, TopHandler, DownHandler;
        public void Run()
        {
            var map = new Map(); 
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
