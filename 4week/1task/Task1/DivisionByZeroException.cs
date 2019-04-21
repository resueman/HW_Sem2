using System;

namespace Task1
{
    /// <summary>
    /// Throws when expression contains operation - division by zero
    /// </summary>
    public class DivisionByZeroException : Exception
    {
        public DivisionByZeroException()
            : base()
        {
        }

        public DivisionByZeroException(string message)
            : base(message)
        {
        }

        public DivisionByZeroException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DivisionByZeroException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
