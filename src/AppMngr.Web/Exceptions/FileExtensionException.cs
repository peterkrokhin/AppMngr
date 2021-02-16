using System;
using System.Runtime.Serialization;

namespace AppMngr.Web
{
    public class FileExtensionException : Exception
    {
        public FileExtensionException()
        {
        }

        public FileExtensionException(string message) : base(message)
        {
        }

        public FileExtensionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileExtensionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}