namespace Task2
{
    /// <summary>
    /// FNV hashes are designed to be fast while maintaining a low collision rate. 
    /// FNV hashes are well suited for hashing nearly identical strings 
    /// such as URLs, hostnames, filenames, text, IP addresses, etc.
    /// </summary>
    /// <typeparam name="T">The type of data stored in hash table</typeparam>
    public class FNVHashFunction<T> : IHashFunction<T>
    {
        /// <summary>
        /// Calculates key's hash
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
