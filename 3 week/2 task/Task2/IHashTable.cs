namespace Task2
{
    interface IHashTable<T>
    {
        bool IsExist(T key);
        bool AddToSet(T key);
        bool DeleteFromSet(T key);
        void PrintHashTable();
    }
}
