using System;
using System.Runtime.Serialization;

namespace AppMngr.Web
{
    public class FileLengthException : Exception
    {
        public FileLengthException()
        {
        }

        public FileLengthException(string message) : base(message)
        {
        }

        public FileLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}