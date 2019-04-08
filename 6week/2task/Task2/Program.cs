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
            try
            {
                eventLoop.Run();
            }
            catch(MapNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                if(exception.InnerException != null)
                {
                    Console.WriteLine(exception.InnerException.Message);
                }
            }
        }
    }
}
