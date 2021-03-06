﻿namespace Task1
{
    public class StackList<T> : IStack<T>
    {
        private Node head;

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        public bool IsEmpty()
            => head == null;

        public T Top()
            => IsEmpty() ? throw new StackIsEmptyException("No top element, stack is empty") : head.Value;

        public void Push(T value)
        {
            var newNode = new Node(value)
            {
                Next = head
            };
            head = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new StackIsEmptyException("Can't pop, stack is empty");
            }
            T topValue = head.Value;
            head = head.Next;
            return topValue;
        }
    }
}
