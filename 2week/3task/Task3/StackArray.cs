using System;

namespace Task3
{
    class StackArray<T> : IStack<T>
    {
        private T[] stack;
        private int head = -1;
        private const int size = 2;

        public StackArray()
        {
            stack = new T[size];
        }

        public bool IsEmpty()
            => head == -1;

        public T Top()
            => IsEmpty() ? throw new StackIsEmptyException("No top element") : stack[head - 1];

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new StackIsEmptyException("Can't pop");
            }
            T headValue = stack[head];
            --head;
            return headValue;
        }

        private void Resize()
        {
            var newArray = new T[2 * stack.Length];
            for (int i = 0; i < stack.Length; ++i)
            {
                newArray[i] = stack[i];
            }
            stack = newArray;
        }

        public void Push(T value)
        {
            if (head == stack.Length - 1)
            {
                Resize();
            }
            ++head;
            stack[head] = value;
        }            
    }
}
