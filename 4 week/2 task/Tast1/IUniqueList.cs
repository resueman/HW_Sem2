u

namespace Task2
{
    interface IUniqueList<T> : IList<T>
    {
        void DeleteNode(T value);
    }
}
