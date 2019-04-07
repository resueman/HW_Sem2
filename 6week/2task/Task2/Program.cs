using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            var eventLoop = new EventLoop();
            eventLoop.LeftHandler += Game.OnLeft;
            eventLoop.RightHandler += Game.OnRight;
            eventLoop.TopHandler += Game.OnTop;
            eventLoop.DownHandler += Game.OnDown;
            eventLoop.Run();
        }
    }
}
