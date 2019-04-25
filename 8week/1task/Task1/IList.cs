namespace Task1
{
    /// <summary>
    /// Functions to work with list
    /// </summary>
    /// <typeparam name="T">Type of list elements</typeparam>
    public interface IList<T>
    {
        /// <summary>
        /// Add element to list by position
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="position">Position where to insert element</param>
        void AddNode(T value, int position);

        /// <summary>
        /// Delete value by position
        /// </summary>
        /// <param name="position">Position of element to be deleted</param>
        void DeleteNode(int position);

        /// <summary>
        /// Get value of element by position
        /// </summary>
        /// <param name="position">Position of value to return</param>
        /// <returns>Value of element</returns>
        T GetValue(int position);

        /// <summary>
        /// Set value of element by position
        /// </summary>
        /// <param name="value"></param>
        /// <param name="position"></param>
        void SetValue(T value, int position);

        /// <summary>
        /// Check if list is empty  
        /// </summary>
        /// <returns>Returns true, if list is empty, else returns false</returns>
        bool IsEmpty();

        /// <summary>
        /// Print elements
        /// </summary>
        void Print();
    }
}
