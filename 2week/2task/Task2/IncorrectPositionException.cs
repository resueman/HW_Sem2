using System;


namespace Task2
{
    [Serializable()]
    public class IncorrectPositionException : Exception
    {
        public IncorrectPositionException()
        {
        }
        public IncorrectPositionException(string message)
            : base(message)
        {
        }
        public IncorrectPositionException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected IncorrectPositionException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public class MyException : Exception
    {
        public MyException()
        {
        }
        public MyException(string message)
            : base(message)
        {
        }
        public MyException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected MyException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
