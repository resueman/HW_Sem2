using System;

namespace Task1
{
    interface IList
    {
        void AddNode(int value, int position);
        void DeleteNode(int position);
        int GetValue(int position);
        void SetValue(int value, int position);
        bool IsEmpty();
    }
}
