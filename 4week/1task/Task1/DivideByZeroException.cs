using System;

namespace Task1
{
    /// <summary>
    /// Throws when expression contains operation - division by zero
    /// </summary>
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException()
            :base()
        {
        }

        public DivideByZeroException(string message)
            : base(message)
        {
        }

        public DivideByZeroException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DivideByZeroException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
