using System;

namespace Task3
{
    [Serializable]
    public class NotPostfixFormException : Exception
    {
        public NotPostfixFormException()
        {
        }
        public NotPostfixFormException(string message)
            : base(message)
        {
        }
        public NotPostfixFormException(string message, Exception inner)
            : base(message, inner)
        {
        }
        // Constructor for a serialization 
        protected NotPostfixFormException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
