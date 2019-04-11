namespace Task2
{
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
