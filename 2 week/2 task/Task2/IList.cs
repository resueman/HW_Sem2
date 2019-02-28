namespace Task2
{
    interface IList
    {
        void AddNode(int value, int position);
        void DeleteNode(int position);
        int GetValue(int position);
        void SetValue(int value, int position);
        int GetLengthOfList();
        bool IsEmpty();
        void PrintList();
    }
}
