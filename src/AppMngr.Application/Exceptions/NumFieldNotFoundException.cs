using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class NumFieldNotFoundException : Exception
    {
        public NumFieldNotFoundException()
        {
        }

        public NumFieldNotFoundException(string message) : base(message)
        {
        }

        public NumFieldNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumFieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}