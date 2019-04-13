using System;

namespace Task1
{
    /// <summary>
    /// Throws when one of the actions 
    /// to evaluate an expression is division by zero
    /// </summary>
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
