using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class DateFieldNotFoundException : Exception
    {
        public DateFieldNotFoundException()
        {
        }

        public DateFieldNotFoundException(string message) : base(message)
        {
        }

        public DateFieldNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateFieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}