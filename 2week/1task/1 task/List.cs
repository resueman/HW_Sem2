using System;

namespace Task1
{
    class List : IList
    {
        private Node head;
        public int Length { get; set; }

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
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

        public void AddNode(int value, int position)
        {
            if (position > Length + 1 && position != 0 || position < 1)
            {
                Console.WriteLine("Incorrect position");
                return;
            }
            var newNode = new Node(value);
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
            if (position > Length || position < 1)
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
            --Length;
        }

        public string GetStringOfListElements()
        {
            if (Length == 0)
            {
                return "List is empty";
            }

            string answer = "";
            Node current = head;
            for (int i = 0; i < Length; ++i)
            {
                answer += current.Value.ToString() + " ";
                current = current.Next;
            }
            return answer;
        }

        public void Clear()
        {
            head = null;
            Length = 0;
        }
    }
}
