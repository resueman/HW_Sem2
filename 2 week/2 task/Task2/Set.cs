using System;

namespace Task2
{
    class Set : ISet
    {
        List[] buckets;
        public int numberOfElements;
        public const int defaultSize = 2;

        public Set()
        {
            buckets = new List[defaultSize];
            for(int i = 0; i < defaultSize; ++i)
            {
                buckets[i] = new List();
            }
        }

        public int LoadFactor()
            => numberOfElements / buckets.Length;

        private void Resize()
        {
            var newBuckets = new List[2 * buckets.Length];
            int[] allNodes = new int[numberOfElements];
            int currentIndex = 0;
            for(int i = 0; i < buckets.Length; ++i)
            {
                newBuckets[i] = new List();
                for(int j = 1; j <= buckets[i].GetLengthOfList(); ++j)
                {
                    allNodes[currentIndex] = buckets[i].GetValue(j);
                    ++currentIndex;
                }
            }
            for(int i = buckets.Length; i < 2 * buckets.Length; ++i)
            {
                newBuckets[i] = new List();
            }
            buckets = newBuckets;
            foreach (int node in allNodes)
            {
                AddToSet(node);
            }
        }

        public bool IsExist(int key)
        {
            int hash = key.GetHashCode() % buckets.Length;
            return buckets[hash].FindNode(key) != -1;
        }

        public void AddToSet(int key)
        {
            if(IsExist(key))
            {
                Console.WriteLine("Such key already exists");
                return;
            }
            if(LoadFactor() >= 1.0)
            {
                Resize();
            }
            int hash = key.GetHashCode() % buckets.Length;
            buckets[hash].AddNode(key, 1 + buckets[hash].GetLengthOfList());
            ++numberOfElements;
            Console.WriteLine("Success\n");
        }

        public void DeleteFromSet(int key)
        {
            int hash = key.GetHashCode() % buckets.Length;
            int position = buckets[hash].FindNode(key);
            if (position == -1)
            {
                Console.WriteLine("No such key");
                return;
            }
            buckets[hash].DeleteNode(position);
            --numberOfElements;
            Console.WriteLine("Success\n");
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
