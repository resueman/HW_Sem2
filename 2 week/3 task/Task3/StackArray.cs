using System;

namespace Task3
{
    class StackArray : IStack
    {
        private int[] stack;
        private int head = -1;

        public StackArray(int size)
        {
            var stack = new int[size];
        }

        public bool IsEmpty()
            => head == -1;

        public int Top()
        => stack[head - 1];

        public int Pop(bool result)
        {
            if (IsEmpty())
            {
                result = false;
                return -666;
            }
            --head;
            return stack[head];
        }

        public void Push(int value)
        {
            stack[head] = value;
            ++head;
        }
    }
}
