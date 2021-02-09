using System;
using System.Runtime.Serialization;

namespace AppMngr.Application
{
    public class FileMetaDataNotFoundException : Exception
    {
        public FileMetaDataNotFoundException()
        {
        }

        public FileMetaDataNotFoundException(string message) : base(message)
        {
        }

        public FileMetaDataNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileMetaDataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}