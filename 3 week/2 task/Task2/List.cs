using System;

namespace Task2
{
    class List<T> : IList<T>
    {
        private int length = 0;
        private Node head = null;

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; } = null;

            public Node(T value)
            {
                Value = value;
            }
        }

        public bool IsEmpty()
        => length == 0;

        public int GetLengthOfList()
        {
            return length;
        }

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
            if (position > length + 1 && position != 0 || position < 1)
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
            ++length;
        }

        private void IsCorrectPosition(int position)
        {
            if (position > length || position < 1)
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
                --length;
            }
            catch (IncorrectPositionException exception)
            {
                throw new ListException("Can't delete node", exception);
            }
        }

        public void PrintList()
        {
            Node current = head;
            for (int i = 0; i < length; ++i)
            {
                Console.Write($"{current.Value.ToString()}  ");
                current = current.Next;
            }
        }

        public void Clear()
        {
            Node current = head;
            while (length > 0)
            {
                DeleteNode(1);
                current = current.Next;
            }
        }

        public int FindPosition(T value)
        {
            if(head == null)
            {
                return -1;
            }
            var current = head;
            for(int i = 0; i < length; ++i)
            {
                if(current.Value.Equals(value))
                {
                    return i + 1; 
                }
                current = current.Next;
            }
            return -1;
        }
    }
}
