namespace Task2
{
    interface ISet
    {
        bool IsExist(int key);
        void AddToSet(int key);
        void DeleteFromSet(int key);
        void PrintHashTable();
    }
}
