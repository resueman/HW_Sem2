using System;

namespace Task2
{
    class JenkinsHashFunction<T> : IHashFunction<T>
    {
        public int Calculate(T input)
        {
            string key = input.ToString();
            int hash = 0;
            for (int i = 0; i < key.Length; ++i)
            {
                hash += key[i];
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);
            return Math.Abs(hash);
        }
    }
}
