using System;

namespace Task2
{
    /// <summary>
    /// Throws when user try to add to list existing value
    /// </summary>
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
