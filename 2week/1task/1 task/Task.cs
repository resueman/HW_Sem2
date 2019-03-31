using System;

namespace Task1
{
    class Task
    {
        public static bool Test()
        {
            var list = new List();

            //TEST1
            if(!list.IsEmpty() || list.GetLengthOfList() != 0)
            {
                return false;
            }

            //TEST 2
            list.AddNode(3, 1);
            if (list.IsEmpty() || list.GetLengthOfList() != 1)
            {
                return false;
            }
            if (list.GetValue(-1) != -666 || list.GetValue(2) != -666 || list.GetValue(1) != 3)
            {
                return false;
            }

            //TEST 3
            list.AddNode(1, 1);
            list.AddNode(9, 4);
            list.AddNode(9, 0);
            list.AddNode(9, 3);
            list.AddNode(7, 3);
            list.AddNode(15, 5);
            list.AddNode(18, 6);
            list.AddNode(27, 7);
            list.AddNode(21, 7);
            list.AddNode(4, 3);
            list.AddNode(0, 1);

            if (list.GetStringOfListElements() != "0 1 3 4 7 9 15 18 21 27 " || list.GetLengthOfList() != 10)
            {
                return false;
            }

            //TEST 4
            list.SetValue(-1, 1);
            list.SetValue(8, 0);
            list.SetValue(8, -1);
            list.SetValue(-3, 3);
            list.SetValue(-27, 10);
            list.SetValue(-7, 5);
            if (list.GetStringOfListElements() != "-1 1 -3 4 -7 9 15 18 21 -27 " || list.GetLengthOfList() != 10)
            {
                return false;
            }

            //TEST 5
            list.DeleteNode(10);
            list.DeleteNode(10);
            list.DeleteNode(0);
            list.DeleteNode(9);
            list.DeleteNode(1);
            list.DeleteNode(1);

            if (list.GetStringOfListElements() != "-3 4 -7 9 15 18 " || list.GetLengthOfList() != 6)
            {
                return false;
            }

            list.DeleteNode(3);
            list.DeleteNode(4);

            if (list.GetStringOfListElements() != "-3 4 9 18 " || list.GetLengthOfList() != 4)
            {
                return false;
            }

            //TEST 6
            list.DeleteNode(2);
            list.DeleteNode(3);
            list.DeleteNode(-1);
            list.DeleteNode(2);
            list.DeleteNode(1);

            if (list.GetStringOfListElements() != "List is empty" || !list.IsEmpty() || list.GetLengthOfList() != 0)
            {
                return false;
            }

            return true;
        }
    }
}
