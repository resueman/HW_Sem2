using System;

namespace Task2
{
    /// <summary>
    /// Class responsible for starting the game,
    /// for subscribing methods on events
    /// for invoking methods after an event occurs
    /// </summary>
    public class EventLoop
    {
        public event Action LeftHandler;
        public event Action RightHandler;
        public event Action TopHandler;
        public event Action DownHandler;

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

        public void Run()
        {
            bool wantToPlay = true;
            while (wantToPlay)
            {
                var key = Console.ReadKey(true);
                Console.Write("\b ");
                wantToPlay = ProcessKey(key.Key);
            }
        }
    }
}
