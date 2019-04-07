using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Game
    {
        public static void OnLeft(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        public static void OnRight(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        public static void OnTop(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        public static void OnDown(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
