namespace Task3
{
    class StackList : IStack
    {
        Node head = null;

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; } = null;

            public Node(int value)
            {
                Value = value;
            }
        }

        public bool IsEmpty()
            => head == null;
       
        public int Top()
            => head.Value;

        public void Push(int value)
        {
            var newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
        }

        public int Pop(ref bool result)
        {
            if (IsEmpty())
            {
                result = false;
                return -666;
            }
            int topValue = head.Value;
            head = head.Next;
            return topValue;
        }
    }
}
