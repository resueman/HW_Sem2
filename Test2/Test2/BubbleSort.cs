using System;
using System.Collections.Generic;
using System.Text;

namespace Test2
{
    /// <summary>
    /// Class that contains Bubble sort for list 
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// Method which sorts list elements
        /// </summary>
        /// <typeparam name="T">Type of list elements</typeparam>
        /// <param name="list">List to sort</param>
        /// <param name="comparer">Object for comparison</param>
        public static void Sort<T>(List<T> list, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("Comparer can't be null!");
            }
            for (int i = 1; i < list.Count; ++i)
            {
                for (int j = 1; j < list.Count; ++j)
                {
                    if (comparer.Compare(list[j - 1], list[j]) > 0)
                    {
                        var temporary = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temporary;
                    }
                }
            }
        }
    }
}
