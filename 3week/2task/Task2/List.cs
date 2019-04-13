using System;
using System.Text;

namespace Task2
{
    /// <summary>
    /// List - data structure for storing objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class List<T> : IList<T>
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

        private bool IsCorrectPosition(int position)
        {
            return !(position > Length || position < 1);
        }

        public T GetValue(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Can't get value, incorrect position");
            }
            return GetPreviousNodeByPosition(position + 1).Value;
        }

        public void SetValue(T value, int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Can't set value, incorrect position");
            }
            GetPreviousNodeByPosition(position + 1).Value = value;
        }

        public void DeleteNode(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Can't delete node, incorrect position");
            }
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

        public void PrintList()
        {
            Console.WriteLine(GetStringOfListElements());
        }
        public string GetStringOfListElements()
        {
            if (Length == 0)
            {
                return "List is empty";
            }
            var stringBuilder = new StringBuilder();
            Node current = head;
            for (int i = 0; i < Length; ++i)
            {
                stringBuilder.Append(current.Value + " ");
                current = current.Next;
            }
            return stringBuilder.ToString();
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
