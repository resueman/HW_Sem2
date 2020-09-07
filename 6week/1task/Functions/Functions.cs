using System;
using System.Collections.Generic;

namespace Functions
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
        /// <typeparam name="InitialType">Initial type of list elements</typeparam>
        /// <typeparam name="FinalType">Final type of list elements</typeparam>
        /// <param name="list">List</param>
        /// <param name="function">Function converting list element</param>
        /// <returns>Changed list</returns>
        public static List<FinalType> Map<InitialType, FinalType>(List<InitialType> list, Func<InitialType, FinalType> function)
        {
            var resultList = new List<FinalType>();
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
        /// <typeparam name="ListType">Type of list elements</typeparam>
        /// <typeparam name="ResultType">Type of accumulated value</typeparam>
        /// <param name="list">List</param>
        /// <param name="initialValue">Initial value</param>
        /// <param name="function">Function, which returns new accumulated value
        /// by current accumulated value and current element</param>
        /// <returns>Accumulated value</returns>
        public static ResultType Fold<ListType, ResultType>(List<ListType> list, ResultType initialValue, Func<ListType, ResultType, ResultType> function)
        {
            ResultType resultOfAccumulation = initialValue;
            foreach (var element in list)
            {
                resultOfAccumulation = function(element, resultOfAccumulation);
            }
            return resultOfAccumulation;
        }
    }
}
