using System;

namespace PriorityQueue
{
    /// <summary>
    /// Throws when user try to delete element from empty queue
    /// </summary>
    [Serializable]
    public class DequeueFromEmptyQueueException : Exception
    {
        public DequeueFromEmptyQueueException()
        {
        }

        public DequeueFromEmptyQueueException(string message)
            : base(message)
        {
        }

        public DequeueFromEmptyQueueException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DequeueFromEmptyQueueException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
