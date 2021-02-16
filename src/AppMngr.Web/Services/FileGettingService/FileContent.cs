using System.IO;

namespace AppMngr.Web
{
    public class FileContent
    {
        public MemoryStream MemoryStream { get; private set; }
        public string ContentType { get; private set; }
        public string FullName { get; private set; }

        public FileContent(MemoryStream memoryStream, string contentType, string fullName)
        {
            MemoryStream = memoryStream;
            ContentType = contentType;
            FullName = fullName;
        }
    }
}