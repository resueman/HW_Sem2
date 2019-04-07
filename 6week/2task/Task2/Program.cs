using System;
using System.IO;
using System.Collections;

namespace Task2
{
    class Program
    {
        public static void PrintMap()
        {
            StreamReader objectReader = new StreamReader("Map.txt");
            string buffer = "";
            while (buffer != null)
            {
                buffer = objectReader.ReadLine();
                if (buffer != null)
                {
                    Console.WriteLine(buffer);
                }
            }
            objectReader.Close();
        }
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
