using System;
using System.Collections.Generic;

namespace Task1
{
    class Functions
    {
        public List<T> Map<T>(List<T> list, Func<T, T> function)
        {
            var resultList = new List<T>();
            foreach (var element in list)
            {
                resultList.Add(function(element));
            }
            return resultList;
        }
        public List<T> Filter<T>(List<T> list, Func<T, bool> function)
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
        public T Fold<T>(List<T> list, T initialValue, Func<T, T, T> function)
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
