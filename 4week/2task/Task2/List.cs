using System;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Structure to store and work with data
    /// </summary>
    /// <typeparam name="T">Type of stored data</typeparam>
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

        private bool IsCorrectPosition(int position)
            => !(position > Length || position < 1);

        public T GetValue(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Can't get value of item, because position is incorrect");
            }
            return GetPreviousNodeByPosition(position + 1).Value;
        }

        public virtual void SetValue(T value, int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Can't set item value, because position is incorrect");
            }
            GetPreviousNodeByPosition(position + 1).Value = value;
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

        public void DeleteNodeByPosition(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Incorrect position");
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

        private void InsertToHead(Node newNode)
        {
            newNode.Next = head;
            head = newNode;
        }

        private void InsertNotToHead(Node newNode, int position)
        {
            var previous = GetPreviousNodeByPosition(position);
            newNode.Next = previous.Next;
            previous.Next = newNode;
        }

        public void AddNode(T value, int position)
        {
            if (position > Length + 1 && position != 0 || position < 1)
            {
                throw new IncorrectPositionException("Incorrect position");
            }
            var newNode = new Node(value);
            if (position == 1)
            {
                InsertToHead(newNode);
            }
            else
            {
                InsertNotToHead(newNode, position);
            }
            ++Length;
        }

        protected int GetPositionByValue(T key)
        {
            var current = head;
            for (int i = 0; i < Length; ++i)
            {
                if (key.Equals(current.Value))
                {
                    return i + 1;
                }
                current = current.Next;
            }
            return -1;
        }

        public void Clear()
        {
            head = null;
            Length = 0;
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

        public void Print()
        {
            Console.WriteLine(GetStringOfListElements() + "\n");
        }
    }
}
