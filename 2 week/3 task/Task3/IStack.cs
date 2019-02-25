using System;

namespace Task3
{
    interface IStack<T>
    {
        T Top();
        T Pop(bool result);
        bool IsEmpty();
        void Push(T value);
    }
}
