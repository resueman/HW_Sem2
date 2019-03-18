using System;

namespace Task1
{
    class Node<T>
    {
        protected T Data { get; set; }
        protected Node<T> Left { get; set; } = null;
        protected Node<T> Right { get; set; } = null;
        
        public Node<T> GetLeft()
            => Left;
        
        public Node<T> GetRight()
            => Right;

        public virtual void PrintNode()
        {
            Console.WriteLine(Data);
        }

    }
}
