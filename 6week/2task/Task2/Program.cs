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
            var eventLoop = new EventLoop();
            try
            {
                eventLoop.Run("Map.txt");
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
