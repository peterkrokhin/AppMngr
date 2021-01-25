using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class StatusNotFoundException : Exception
    {
        public StatusNotFoundException()
        {
        }

        public StatusNotFoundException(string message) : base(message)
        {
        }

        public StatusNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StatusNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}