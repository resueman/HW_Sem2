using System;

namespace Task1
{
    interface IList
    {
        void AddNode(int position, int value);
        void DeleteNode(int position);
        int GetValue(int position);
        void ChangeValue(int position, int value);
        int GetLengthOfList();
        bool IsEmpty();
    }
}
