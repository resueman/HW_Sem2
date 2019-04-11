using System;

namespace Task2
{
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

        public HashTable(IHashFunction<T> hash)
        {
            this.hash = hash;

            buckets = new List<T>[defaultSize];
            for(int i = 0; i < defaultSize; ++i)
            {
                buckets[i] = new List<T>();
            }
        }

        public int LoadFactor()
            => numberOfElements / buckets.Length;

        private void Resize()
        {
            var newBuckets = new List<T>[2 * buckets.Length];
            for (int i = 0; i < newBuckets.Length; ++i)
            {
                newBuckets[i] = new List<T>();
            }
            var allNodes = new T[numberOfElements];
            int currentIndex = 0;
            for (int i = 0; i < buckets.Length; ++i)
            {
                for(int j = 1; j <= buckets[i].Length; ++j)
                {
                    allNodes[currentIndex] = buckets[i].GetValue(j);
                    ++currentIndex;
                }
            }
            buckets = newBuckets;
            numberOfElements = 0;
            foreach (T node in allNodes)
            {
                AddToSet(node);
            }
        }

        public bool IsExist(T key)
            => buckets[hash.Calculate(key) % buckets.Length].FindPosition(key) != -1;        

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
            int newElementHash = hash.Calculate(key) % buckets.Length;
            int position = 1 + buckets[newElementHash].Length;
            buckets[newElementHash].AddNode(key, position);
            ++numberOfElements;
            return true;
        }

        public bool DeleteFromSet(T key)
        {
            int hashResult = hash.Calculate(key) % buckets.Length;
            int position = buckets[hashResult].FindPosition(key);
            if (position == -1)
            {
                return false;
            }
            buckets[hashResult].DeleteNode(position);
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
            var newBuckets = new List<T>[defaultSize];
            buckets = newBuckets;
        }
    }
}
