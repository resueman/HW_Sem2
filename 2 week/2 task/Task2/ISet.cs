namespace Task2
{
    interface ISet<T>
    {
        bool IsExist(T key);
        bool AddToSet(T key);
        bool DeleteFromSet(T key);
        void PrintHashTable();
    }
}
