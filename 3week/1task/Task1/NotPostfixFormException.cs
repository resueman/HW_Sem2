using System;

namespace Task1
{
    /// <summary>
    /// Throws when user entered a non-postfix expression
    /// </summary>
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

        protected NotPostfixFormException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
