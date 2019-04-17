using System;
using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Functions that accept list and function, which works with list element
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Returns list, obtained by applying the transferred function
        /// to each element of the transferred list
        /// </summary>
        /// <typeparam name="T">Type of list elements</typeparam>
        /// <param name="list">List</param>
        /// <param name="function">Function converting list element</param>
        /// <returns>Changed list</returns>
        public static List<T> Map<T>(List<T> list, Func<T, T> function)
        {
            var resultList = new List<T>();
            foreach (var element in list)
            {
                resultList.Add(function(element));
            }
            return resultList;
        }

        /// <summary>
        /// Returns list consisting of those elements of the transferred list, 
        /// for which the transferred function returned true.
        /// </summary>
        /// <typeparam name="T">Type of list elements</typeparam>
        /// <param name="list">List</param>
        /// <param name="function">Function which returns boolean value</param>
        /// <returns>Changed list</returns>
        public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
        {
            var newList = new List<T>();
            foreach (var element in list)
            {
                if (function(element))
                {
                    newList.Add(element);
                }
            }
            return newList;
        }

        /// <summary>
        /// Returns the accumulated value, which is obtained 
        /// after the entire passage of the list.
        /// </summary>
        /// <typeparam name="T">Type of list elements</typeparam>
        /// <param name="list">List</param>
        /// <param name="initialValue">Initial value</param>
        /// <param name="function">Function, which returns new accumulated value
        /// by current accumulated value and current element</param>
        /// <returns>Accumulated value</returns>
        public static T Fold<T>(List<T> list, T initialValue, Func<T, T, T> function)
        {
            T resultOfAccumulation = initialValue;
            foreach (var element in list)
            {
                resultOfAccumulation = function(element, resultOfAccumulation);
            }
            return resultOfAccumulation;
        }
    }
}
