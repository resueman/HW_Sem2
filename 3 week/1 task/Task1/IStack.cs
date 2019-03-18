namespace Task1
{
    interface IStack<T>
    {
        T Top();
        T Pop();
        bool IsEmpty();
        void Push(T value);
    }
}
