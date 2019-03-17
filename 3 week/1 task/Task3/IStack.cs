using System;

namespace Task3
{
    public interface IStack
    {
        int Top();
        int Pop(ref bool result);
        bool IsEmpty();
        void Push(int value);
    }
}
