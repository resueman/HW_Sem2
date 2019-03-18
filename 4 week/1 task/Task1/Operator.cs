using System;

namespace Task1
{
    class Operator : Node<string>
    {
        public override void PrintNode()
        {
            Console.Write("(");
            base.PrintNode();            
        }
    }
}
