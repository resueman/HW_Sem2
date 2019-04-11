namespace Task2
{
    class FNVHashFunction<T> : IHashFunction<T>
    {
        /// <summary>
        /// Calculates key hash
        /// </summary>
        /// <param name="input">Key</param>
        /// <returns>Returns the value of key hash</returns>
        public int Calculate(T input)
        {
            string key = input.ToString();
            const int primeNumber = 17;
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash *= primeNumber;
                hash ^= ((byte)key[i]);
            }
            return hash;
        }    
    }
}
