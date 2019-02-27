using System;

namespace Task1
{
    class List : IList
    {
        private int length = 0;
        private Node head = null;

        private class Node
        {
            public int Value { get; set; } = 0;
            public Node Next { get; set; } = null;

            public Node(int value)
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

        public void AddNode(int value, int position)
        {
            if (position > length + 1 && position != 0 || position < 1)
            {
                Console.WriteLine("Incorrect position");
                return;
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

        private bool IsCorrectPosition(int position)
        {
            if (position > length || position < 1)
            {
                Console.WriteLine("Incorrect position");
                return false;
            }
            return true;
        }

        public int GetValue(int position)
        {
            if (!IsCorrectPosition(position))
            {
                return -666;
            }
            return GetPreviousNodeByPosition(position + 1).Value;
        }

        public void SetValue(int value, int position)
        {
            if (!IsCorrectPosition(position))
            {
                return;
            }
            GetPreviousNodeByPosition(position + 1).Value = value;
        }

        public void DeleteNode(int position)
        {
            if (!IsCorrectPosition(position))
            {
                return;
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
            --length;
        }

        public string GetStringOfListElements()
        {
            if (length == 0)
            {
                return "List is empty";
            }

            string answer = "";
            Node current = head;
            for (int i = 0; i < length; ++i)
            {
                answer += current.Value.ToString() + " ";
                current = current.Next;
            }
            return answer;
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
    }
}
