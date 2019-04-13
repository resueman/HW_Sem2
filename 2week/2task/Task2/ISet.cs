namespace Task2
{
    interface ISet<T>
    {
        bool IsExists(T key);
        bool AddToSet(T key);
        bool DeleteFromSet(T key);
        void PrintHashTable();
    }
}
