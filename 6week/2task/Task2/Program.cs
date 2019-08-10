using System;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Class responsible for starting the game and catching exceptions
    /// </summary>
    static class Program
    {
        static void Main()
        { 
            try
            {                
                var game = new Game("Map.txt");                
                var eventLoop = new EventLoop();
                eventLoop.LeftHandler += game.OnLeft;
                eventLoop.RightHandler += game.OnRight;
                eventLoop.TopHandler += game.OnTop;
                eventLoop.DownHandler += game.OnDown;
                eventLoop.Run();
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (IncorrectMapException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
