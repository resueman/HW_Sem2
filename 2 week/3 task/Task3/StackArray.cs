using System;

namespace Task3
{
    class StackArray<T>
    {
        private T[] stack;
        private int head = -1;

        public StackArray(int size)
        {
            var stack = new int[size];
        }

        public bool IsEmpty()
            => head == -1;

        public T Top()
        => stack[head - 1];

        public T Pop(bool result)
        {
            if (IsEmpty())
            {
                result = false;
                throw new Exception("Stack is empty!");
            }
            --head;
            return stack[head];
        }

        public void Push(T value)
        {
            stack[head] = value;
            ++head;
        }
    }
}
