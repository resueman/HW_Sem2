using System;

namespace Task2
{
    class List<T> : IList<T>
    {
        public int Length { get; private set; }
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
           => Length == 0;

        private Node GetPreviousNodeByPosition(int position)
        {
            Node current = head;
            for (int i = 0; i < position - 2; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        private void InsertToHead(Node newNode)
        {
            newNode.Next = head;
            head = newNode;
        }

        private void Insert(Node newNode, int position)
        {
            var previous = GetPreviousNodeByPosition(position);
            newNode.Next = previous.Next;
            previous.Next = newNode;
        }

        public void AddNode(T value, int position)
        {
            if (position > Length + 1 && position != 0 || position < 1)
            {
                throw new IncorrectPositionException("Can't add node, incorrect position");
            }
            Node newNode = new Node(value);
            if (position == 1)
            {
                InsertToHead(newNode);
            }
            else
            {
                Insert(newNode, position);
            }
            ++Length;
        }

        private void IsCorrectPosition(int position)
        {
            if (position > Length || position < 1)
            {
                throw new IncorrectPositionException("Incorrect position");
            }
        }

        public T GetValue(int position)
        {
            try
            {
                IsCorrectPosition(position);
                return GetPreviousNodeByPosition(position + 1).Value;
            }
            catch (IncorrectPositionException exception)
            {
                throw new ListException("Can't get value", exception);
            }
        }

        public void SetValue(T value, int position)
        {
            try
            {
                IsCorrectPosition(position);
                GetPreviousNodeByPosition(position + 1).Value = value;
            }
            catch (IncorrectPositionException exception)
            {
                throw new ListException("Can't set value", exception);
            }
        }

        public void DeleteNode(int position)
        {
            try
            {
                IsCorrectPosition(position);
                if (position == 1)
                {
                    head = head.Next;
                }
                else
                {
                    var previousNode = GetPreviousNodeByPosition(position);
                    previousNode.Next = previousNode.Next.Next;
                }
                --Length;
            }
            catch (IncorrectPositionException exception)
            {
                throw new ListException("Can't delete node", exception);
            }
        }

        public void PrintList()
        {
            Node current = head;
            for (int i = 0; i < Length; ++i)
            {
                Console.Write($"{current.Value.ToString()}  ");
                current = current.Next;
            }
        }

        public void Clear()
        {
            head = null;
            Length = 0;
        }

        public int FindPosition(T value)
        {
            if (head == null)
            {
                return -1;
            }
            var current = head;
            for (int i = 0; i < Length; ++i)
            {
                if (current.Value.Equals(value))
                {
                    return i + 1; 
                }
                current = current.Next;
            }
            return -1;
        }
    }
}
