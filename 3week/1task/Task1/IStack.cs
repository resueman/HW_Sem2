namespace Task1
{
    /// <summary>
    /// Functions to work with stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStack<T>
    {
        /// <summary>
        /// Get value from top of stack
        /// </summary>
        /// <returns>Value from top of stack</returns>
        T Top();

        /// <summary>
        /// Delete element from top of stack
        /// </summary>
        /// <returns>Value of deleted element</returns>
        T Pop();

        /// <summary>
        /// Check if stack is empty
        /// </summary>
        /// <returns>Returns true if stack is empty, else returns false</returns>
        bool IsEmpty();
        
        /// <summary>
        /// Add element to stack
        /// </summary>
        /// <param name="value">Value of added element</param>
        void Push(T value);
    }
}
