using System;

namespace Task2
{
    [Serializable]
    public class DeleteNonExistentNodeException : Exception
    {
        public DeleteNonExistentNodeException()
        {
        }
        public DeleteNonExistentNodeException(string message)
            : base(message)
        {
        }
        public DeleteNonExistentNodeException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected DeleteNonExistentNodeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
