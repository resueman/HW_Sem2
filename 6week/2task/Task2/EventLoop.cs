using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class EventLoop
    {
        public event Action<int, int> LeftHandler;
        public event Action<int, int> RightHandler;
        public event Action<int, int> TopHandler;
        public event Action<int, int> DownHandler;
        public void Run()
        {
            Program.PrintMap();
            int left = 1;
            int top = 1;
            Console.SetCursorPosition(left, top);
            Console.Write("@");

            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        --left;
                        LeftHandler?.Invoke(left, top);
                        break;
                    case ConsoleKey.RightArrow:
                        ++left;
                        RightHandler?.Invoke(left, top);
                        break;
                    case ConsoleKey.UpArrow:
                        --top;
                        TopHandler?.Invoke(left, top);
                        break;
                    case ConsoleKey.DownArrow:
                        ++top;
                        DownHandler?.Invoke(left, top);
                        break;
                }
                Console.Write("@");
            }
        }
    }
}
