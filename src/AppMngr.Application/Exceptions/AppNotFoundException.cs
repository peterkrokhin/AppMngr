using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class AppNotFoundException : Exception
    {
        public AppNotFoundException()
        {
        }

        public AppNotFoundException(string message) : base(message)
        {
        }

        public AppNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}