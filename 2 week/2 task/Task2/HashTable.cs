namespace Task2
{
    class HashTable<T>//:IHashTable<T>
    {
        List<T>[] buckets;

        public HashTable(int size)
        {
            Resize(size);
        }

        private void Resize(int size)
        {
            var newBuckets = new List<T>[size];
            buckets = newBuckets;
        }

        public void AddToHashTable(T input)
        {
            int hash = input.GetHashCode() % buckets.Length;
            buckets[hash].AddNode(input, 1);
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i].PrintList();
            }
        }

        public double LoadFactor()
        {
            int filled = 0;
            for (int i = 0; i < buckets.Length; ++i)
            {
                if (buckets[i] != null)
                {
                    ++filled;
                }
            }
            return 1.0 * filled / buckets.Length;
        }

        int AverageListLength()
        {
            int lenghtSum = 0;
            for (int i = 0; i < buckets.Length; ++i)
            {
                if (buckets[i] != null)
                {
                    lenghtSum += buckets[i].GetLengthOfList();
                }
            }
            return lenghtSum / buckets.Length;
        }

        int MaxListLength()
        {
            int maxListLenght = 0;
            for (int i = 0; i < buckets.Length; ++i)
            {
                if (buckets[i] != null)
                {
                    int currentLenght = buckets[i].GetLengthOfList();
                    if (currentLenght > maxListLenght)
                    {
                        maxListLenght = currentLenght;
                    }
                }
            }
            return maxListLenght;
        }
    }
}
