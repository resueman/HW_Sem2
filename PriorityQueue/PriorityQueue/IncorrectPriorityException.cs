using System;

namespace PriorityQueue
{
    /// <summary>
    /// Throws when value of priority < 0
    /// </summary>
    [Serializable]
    public class IncorrectPriorityException : Exception
    {
        public IncorrectPriorityException()
        {
        }

        public IncorrectPriorityException(string message)
            : base(message)
        {
        }

        public IncorrectPriorityException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IncorrectPriorityException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
