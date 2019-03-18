using System;

namespace Task2
{
    interface IList<T> 
    {
        void AddNode(T value, int position);
        void AddNode(T value);

        void DeleteNodeByPosition(int position);

        void DeleteNode(T value);

        T GetValue(int position);

        void SetValue(T value, int position);

        int GetLengthOfList();

        bool IsEmpty();

        int GetPositionByValue(T key);
    }
}
