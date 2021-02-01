using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class StringFieldNotFoundException : Exception
    {
        public StringFieldNotFoundException()
        {
        }

        public StringFieldNotFoundException(string message) : base(message)
        {
        }

        public StringFieldNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StringFieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}