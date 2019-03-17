namespace Task3
{
    class StackList : IStack
    {
        Node head = null;

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
            => head == null;

        public int Top()
            => IsEmpty() ? throw new StackIsEmptyException("No top element") : head.Value;

        public void Push(int value)
        {
            var newNode = new Node(value)
            {
                Next = head
            };
            head = newNode;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new StackIsEmptyException("Can't pop");
            }
            int topValue = head.Value;
            head = head.Next;
            return topValue;
        }
    }
}
