using System;


namespace Task2
{
    /// <summary>
    /// Kind of extenal exception
    /// to specify that problems occured in list 
    /// </summary>
    [Serializable]
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
