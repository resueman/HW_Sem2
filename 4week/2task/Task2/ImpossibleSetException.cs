using System;

namespace Task2
{
    /// <summary>
    /// Throws when
    /// </summary>
    [Serializable]
    public class ImpossibleSetException : Exception
    {
        public ImpossibleSetException()
        {
        }

        public ImpossibleSetException(string message)
            : base(message)
        {
        }

        public ImpossibleSetException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ImpossibleSetException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
