namespace Task1
{
    public interface IStack<T>
    {
        T Top();
        T Pop();
        bool IsEmpty();
        void Push(T value);
    }
}
