using System;
using System.Runtime.Serialization;

namespace AppMngr.Web
{
    public class FileUploadException : Exception
    {
        public FileUploadException()
        {
        }

        public FileUploadException(string message) : base(message)
        {
        }

        public FileUploadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileUploadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}