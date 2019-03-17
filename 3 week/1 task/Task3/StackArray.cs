namespace Task3
{
    public class StackArray : IStack
    {
        private int[] stack;
        private int head = -1;
        private const int size = 2;

        public StackArray()
        {
            stack = new int[size];
        }

        public bool IsEmpty()
            => head == -1;

        public int Top()
        => stack[head - 1];

        public int Pop(ref bool result)
        {
            if (IsEmpty())
            {
                result = false;
                return -666;
            }
            int headValue = stack[head];
            --head;
            return headValue;
        }

        private void Resize()
        {
            int[] newArray = new int[2 * stack.Length];
            for (int i = 0; i < stack.Length; ++i)
            {
                newArray[i] = stack[i];
            }
            stack = newArray;
        }

        public void Push(int value)
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
