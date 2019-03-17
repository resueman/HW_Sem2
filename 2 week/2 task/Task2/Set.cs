using System;

namespace Task2
{
    class Set<T> : ISet<T>
    {
        List<T>[] buckets;
        private int numberOfElements;
        public const int defaultSize = 2;

        public Set()
        {
            buckets = new List<T>[defaultSize];
            for(int i = 0; i < defaultSize; ++i)
            {
                buckets[i] = new List<T>();
            }
        }

        public int LoadFactor()
            => numberOfElements / buckets.Length;

        private int GetHash(T key)
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

        private void Resize()
        {
            var newBuckets = new List<T>[2 * buckets.Length];
            for(int i = 0; i < newBuckets.Length; ++i)
            {
                newBuckets[i] = new List<T>();
            }
            var allNodes = new T[numberOfElements];
            int currentIndex = 0;
            for(int i = 0; i < buckets.Length; ++i)
            {
                for(int j = 1; j <= buckets[i].GetLengthOfList(); ++j)
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
            => buckets[GetHash(key) % buckets.Length].FindPosition(key) != -1;        

        public bool AddToSet(T key)
        {
            if(IsExist(key))
            {
                return false;
            }
            if(LoadFactor() > 1.0)
            {
                Resize();
            }
            int hash = GetHash(key) % buckets.Length;
            buckets[hash].AddNode(key, 1 + buckets[hash].GetLengthOfList());
            ++numberOfElements;
            return true;
        }

        public bool DeleteFromSet(T key)
        {
            int hash = GetHash(key) % buckets.Length;
            int position = buckets[hash].FindPosition(key);
            if (position == -1)
            {
                return false;
            }
            buckets[hash].DeleteNode(position);
            --numberOfElements;
            return true;
        }

        public void PrintHashTable()
        {
            if (numberOfElements == 0)
            {
                Console.WriteLine("Set is Empty\n");
                return;
            }
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i].PrintList();
            }
            Console.WriteLine("\n");
        }      
    }
}
