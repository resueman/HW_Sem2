namespace Task2
{
    interface IList<T>
    {
        void AddNode(T value, int position);
        void DeleteNode(int position);
        T GetValue(int position);
        void SetValue(T value, int position);
        int GetLengthOfList();
        bool IsEmpty();
    }
}
