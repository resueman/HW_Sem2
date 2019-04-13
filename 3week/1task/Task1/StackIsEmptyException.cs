using System;

namespace Task1
{
    /// <summary>
    /// Throws after attempt to delete an element from empty stack
    /// </summary>
    [Serializable]
    public class StackIsEmptyException : Exception
    {
        public StackIsEmptyException()
        {
        }

        public StackIsEmptyException(string message)
            : base(message)
        {
        }

        public StackIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected StackIsEmptyException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
