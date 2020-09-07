namespace Task2
{
    /// <summary>
    /// Hash table interface. Functions to work with set.
    /// </summary>
    /// <typeparam name="T">The type of data stored in hash table</typeparam>
    interface IHashTable<T>
    {
        /// <summary>
        /// Checks if key exists
        /// </summary>
        /// <param name="key">Key for verification</param>
        /// <returns>True if key exists, else returns false</returns>
        bool IsExist(T key);

        /// <summary>
        /// Add new key to set
        /// </summary>
        /// <param name="key">Key to add</param>
        /// <returns>False, if key was added earlier, true, if key added</returns>
        bool AddToSet(T key);

        /// <summary>
        /// Deletes key from set
        /// </summary>
        /// <param name="key">Key to delete</param>
        /// <returns>Returns false, if key doesn't exists, true, if key deleted</returns>
        bool DeleteFromSet(T key);

        /// <summary>
        /// Prints all keys
        /// </summary>
        void PrintHashTable();
    }
}
