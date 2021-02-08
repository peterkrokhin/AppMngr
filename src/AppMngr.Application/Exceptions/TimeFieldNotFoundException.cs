using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class TimeFieldNotFoundException : Exception
    {
        public TimeFieldNotFoundException()
        {
        }

        public TimeFieldNotFoundException(string message) : base(message)
        {
        }

        public TimeFieldNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TimeFieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}