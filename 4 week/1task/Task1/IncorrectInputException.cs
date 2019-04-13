using System;

namespace Task1
{
    class IncorrectInputException : Exception
    {
        public IncorrectInputException() 
            : base()
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
