using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class AppTypeNotFoundException : Exception
    {
        public AppTypeNotFoundException()
        {
        }

        public AppTypeNotFoundException(string message) : base(message)
        {
        }

        public AppTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}