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
            => length;

        private bool IsCorrectPosition(int position)
            => !(position > length || position < 1);

        public T GetValue(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Can't get value of item, because position is incorrect");
            }
            return GetPreviousNodeByPosition(position + 1).Value;
        }

        public void SetValue(T value, int position)
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

        public void DeleteNode(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new DeleteNonExistentNodeException("Can't delete node which doesn't exist");
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
            if (position > length + 1 && position != 0 || position < 1)
            {
                throw new AddExistingNodeException("Impossible to add node which already exists");
            }
            Node newNode = new Node(value);
            if (position == 1)
            {
                InsertToHead(newNode);
            }
            else
            {
                InsertNotToHead(newNode, position);
            }
            ++length;
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
