using System;
using System.Collections.Generic;

namespace Task1
{
    public static class Functions
    {
        public static List<T> Map<T>(List<T> list, Func<T, T> function)
        {
            var resultList = new List<T>();
            foreach (var element in list)
            {
                resultList.Add(function(element));
            }
            return resultList;
        }

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
