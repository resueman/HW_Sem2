using System;


namespace Task2
{
    public class ListException : Exception
    {
        public ListException()
        {
        }

        public ListException(string message)
            : base(message)
        {
        }

        public ListException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ListException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
