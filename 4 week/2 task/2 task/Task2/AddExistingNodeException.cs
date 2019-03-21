using System;

namespace Task2
{
    [Serializable]
    public class AddExistingNodeException : Exception
    {
        public AddExistingNodeException()
        {
        }
        public AddExistingNodeException(string message)
            : base(message)
        {
        }
        public AddExistingNodeException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected AddExistingNodeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
