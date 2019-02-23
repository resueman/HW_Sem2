using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            List list = new List();

            list.AddNode(7, 1);//
            list.DeleteNode(5);

            list.GetLengthOfList();//
            list.IsEmpty();//

            list.SetValue(8, 1);//
            list.GetValue(5);//
        }
    }
}
