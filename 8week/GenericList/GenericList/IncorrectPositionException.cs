﻿using System;

namespace GenericList
{
    /// <summary>
    /// Throws when position of value in list 
    /// user want to delete, add, get or change 
    /// is incorrect
    /// </summary>
    [Serializable]
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
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
