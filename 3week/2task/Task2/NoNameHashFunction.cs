using System;

namespace Task2
{
    public class NoNameHashFunction<T> : IHashFunction<T>
    {
        public int Calculate(T key)
        {
            int hash = 0;
            int randomNumber = 11;
            string str = key.ToString();
            for (int i = 0; i < str.Length; ++i)
            {
                hash += hash * randomNumber + str[i];
                randomNumber += randomNumber;
            }
            return Math.Abs(hash);
        }
    }    
}
