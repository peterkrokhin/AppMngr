using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class NotEqualAppTypeException : Exception
    {
        public NotEqualAppTypeException()
        {
        }

        public NotEqualAppTypeException(string message) : base(message)
        {
        }

        public NotEqualAppTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotEqualAppTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}