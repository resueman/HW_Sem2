using System;

namespace Task3
{
    interface IStack
    {
        int Top();
        int Pop();
        bool IsEmpty();
        void Push(int value);
    }
}
