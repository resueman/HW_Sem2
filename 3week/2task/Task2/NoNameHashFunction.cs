namespace Task2
{
    public class NoNameHashFunction<T> : IHashFunction<T>
    {
        /// <summary>
        /// Calculates key hash
        /// </summary>
        /// <param name="input">Key</param>
        /// <returns>Returns the value of key hash</returns>
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
            return hash;
        }
    }    
}
