using System;

namespace Task1
{
    [Serializable]
    public class DivisionByZeroException : Exception
    {
        public DivisionByZeroException()
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
