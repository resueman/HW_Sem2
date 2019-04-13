namespace Task2
{
    /// <summary>
    /// Interface for hash function which compute an index
    /// into an array of buckets, from which the desired value can be found.
    /// </summary>
    /// <typeparam name="T">Type of data stored in hash table</typeparam>
    public interface IHashFunction<T>
    {
        /// <summary>
        /// Calculates hash of element
        /// </summary>
        /// <param name="key">Key whose value needs to be calculated</param>
        /// <returns>Hash</returns>
        int Calculate(T key);
    }
}
