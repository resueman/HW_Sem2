namespace Task1
{
    public class StackArray<T> : IStack<T>
    {
        private T[] stack;
        private int head = -1;
        private const int defaultSize = 2;

        public StackArray()
        {
            stack = new T[defaultSize];
        }

        public bool IsEmpty()
            => head == -1;

        public T Top()
            => IsEmpty() ? throw new StackIsEmptyException("No top element, stack is empty") : stack[head];

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new StackIsEmptyException("Can't pop, stack is empty");
            }
            T headValue = stack[head];
            stack[head] = default;
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
