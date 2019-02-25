using System;

namespace Task3
{
    class StackList<T> : IStack<T>
    {
        Node head = null;

        class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; } = null;

            public Node(T value)
            {
                Value = value;
            }
        }

        public bool IsEmpty()
            => head == null;
       
        public T Top()
            => head.Value;

        public void Push(T value)
        {
            var newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
        }

        public T Pop(bool result)
        {
            if (IsEmpty())
            {
                result = false;
                throw new Exception("Stack is empty!");
            }
            T topValue = head.Value;
            head = head.Next;
            return topValue;
        }
    }
}
