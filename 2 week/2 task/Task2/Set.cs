using System;

namespace Task2
{
    class Set : ISet
    {
        List[] buckets;
        private int numberOfElements;
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

        private int Hash(int key)
        {
            int hash = Math.Abs(key.GetHashCode()) % buckets.Length;
            return hash;
        }

        private void Resize()
        {
            var newBuckets = new List[2 * buckets.Length];
            for(int i = 0; i < newBuckets.Length; ++i)
            {
                newBuckets[i] = new List();
            }
            int[] allNodes = new int[numberOfElements];
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
            foreach (int node in allNodes)
            {
                AddToSet(node);
            }
        }

        public bool IsExist(int key)
            => buckets[Hash(key)].FindNode(key) != -1;        

        public bool AddToSet(int key)
        {
            if(IsExist(key))
            {
                return false;
            }
            if(LoadFactor() > 1.0)
            {
                Resize();
            }
            int hash = Hash(key);
            buckets[hash].AddNode(key, 1 + buckets[hash].GetLengthOfList());
            ++numberOfElements;
            return true;
        }

        public bool DeleteFromSet(int key)
        {
            int hash = Hash(key);
            int position = buckets[hash].FindNode(key);
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
