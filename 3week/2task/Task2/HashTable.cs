using System;

namespace Task2
{
    /// <summary>
    /// Data structure that implements an associative array abstract data type
    /// Can map keys to values using a hash function 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTable<T> : IHashTable<T>
    {
        private List<T>[] buckets;
        private int numberOfElements;
        private const int defaultSize = 2;
        private readonly IHashFunction<T> hash;

        public HashTable()
        {
            hash = new NoNameHashFunction<T>();
        }        

        public HashTable(IHashFunction<T> hashFunction)
        {
            hash = hashFunction;

            buckets = new List<T>[defaultSize];
            for (int i = 0; i < defaultSize; ++i)
            {
                buckets[i] = new List<T>();
            }
        }

        private int IndexByHash(T key)
            => Math.Abs(hash.Calculate(key)) % buckets.Length;

        public int LoadFactor()
            => numberOfElements / buckets.Length;

        private void Resize()
        {
            var allKeys = new T[numberOfElements];
            int currentIndex = 0;
            for (int i = 0; i < buckets.Length; ++i)
            {
                for (int j = 1; j <= buckets[i].Length; ++j)
                {
                    allKeys[currentIndex] = buckets[i].GetValue(j);
                    ++currentIndex;
                }
            }
            buckets = new List<T>[2 * buckets.Length];
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List<T>();
            }

            numberOfElements = 0;
            foreach (T node in allKeys)
            {
                AddToSet(node);
            }
        }

        public bool IsExist(T key)
            => buckets[IndexByHash(key)].FindPosition(key) != -1;        

        public bool AddToSet(T key)
        {
            if (IsExist(key))
            {
                return false;
            }
            if (LoadFactor() > 1.0)
            {
                Resize();
            }
            int newElementHash = IndexByHash(key);
            int position = 1 + buckets[newElementHash].Length;
            buckets[newElementHash].AddNode(key, position);
            ++numberOfElements;
            return true;
        }

        public bool DeleteFromSet(T key)
        {
            int hashInSet = IndexByHash(key);
            int position = buckets[hashInSet].FindPosition(key);
            if (position == -1)
            {
                return false;
            }
            buckets[hashInSet].DeleteNode(position);
            --numberOfElements;
            return true;
        }

        public void PrintHashTable()
        {
            if (numberOfElements == 0)
            {
                Console.WriteLine("Set is empty\n");
                return;
            }
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i].PrintList();
            }
            Console.WriteLine("\n");
        }      

        public void Clear()
        {
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i].Clear();
            }
            buckets = new List<T>[defaultSize];
        }
    }
}
