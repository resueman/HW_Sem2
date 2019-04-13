using System;

namespace Task2
{
    /// <summary>
    /// Throws if file with map wasn't found
    /// </summary>
    [Serializable]
    public class MapNotFoundException : Exception
    {
        public MapNotFoundException()
        {
        }
        public MapNotFoundException(string message)
            : base(message)
        {
        }
        public MapNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected MapNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
