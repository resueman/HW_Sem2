using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Throws when infix form of expression is incorrect
    /// </summary>
    [Serializable]
    public class IncorrectInfixExpressionException : Exception
    {
        public IncorrectInfixExpressionException()
        {
        }

        public IncorrectInfixExpressionException(string message)
            : base(message)
        {
        }

        public IncorrectInfixExpressionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IncorrectInfixExpressionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}

