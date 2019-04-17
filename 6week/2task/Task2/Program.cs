using System;
using System.IO;

namespace Task2
{
    class Program
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
