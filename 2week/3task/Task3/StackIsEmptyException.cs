using System;

namespace Task3
{
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
        // Constructor for a serialization 
        protected StackIsEmptyException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
