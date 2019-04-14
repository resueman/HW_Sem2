using System;
using System.IO;

namespace Task2
{
    class Program
    {
        public static void GameSettings()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        static void Main()
        {
            GameSettings();
            var eventLoop = new EventLoop();
            try
            {
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
