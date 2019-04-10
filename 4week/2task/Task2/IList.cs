namespace Task2
{
    interface IList<T>
    {
        void AddNode(T value, int position);

        void DeleteNodeByPosition(int position);

        T GetValue(int position);

        void SetValue(T value, int position);

        bool IsEmpty();

        void Print();
    }
}
