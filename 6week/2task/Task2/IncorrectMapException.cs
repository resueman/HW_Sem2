using System;

namespace Task2
{
    /// <summary>
    /// Throws if there was no hero start position on map
    /// </summary>
    [Serializable]
    public class IncorrectMapException : Exception
    {
        public IncorrectMapException()
        {
        }

        public IncorrectMapException(string message)
            : base(message)
        {
        }

        public IncorrectMapException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IncorrectMapException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
