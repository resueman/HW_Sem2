namespace Task1
{
    /// <summary>
    /// Stack interface
    /// </summary>
    /// <typeparam name="T">Type of stack elements</typeparam>
    public interface IStack<T>
    {
        /// <summary>
        /// Returns last added element
        /// </summary>
        /// <returns>Element from top of stack</returns>
        T Top();

        /// <summary>
        /// Deletes element from top of stack
        /// </summary>
        /// <returns>Value of popped element</returns>
        T Pop();

        /// <summary>
        /// Checks if stack is empty
        /// </summary>
        /// <returns>True if stack is empty, false if stack isn't empty </returns>
        bool IsEmpty();

        /// <summary>
        /// Add element to top of stack
        /// </summary>
        /// <param name="value">Value to add</param>
        void Push(T value);
    }
}
