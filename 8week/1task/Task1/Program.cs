using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.AddNode(6, 1);
            list.AddNode(3, 1);
            list.AddNode(6, 1);
            list.AddNode(8, 1);
            list.AddNode(9, 1);
            list.AddNode(1, 1);
            Console.WriteLine(list.ToString());
        }
    }
}
