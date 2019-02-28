namespace Task2
{
    interface ISet
    {
        bool IsExist(int key);
        bool AddToSet(int key);
        bool DeleteFromSet(int key);
        void PrintHashTable();
    }
}
