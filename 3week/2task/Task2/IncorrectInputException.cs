using System;

namespace Task2
{
    /// <summary>
    /// Throws if user enter incorrect data
    /// Doesn't enter number, where it required
    /// Demands hash function, which doesn't exist
    /// </summary>
    [Serializable]
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException()
        {
        }

        public IncorrectInputException(string message)
            : base(message)
        {
        }

        public IncorrectInputException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IncorrectInputException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
