using System.IO;

namespace AppMngr.Web
{
    public class FileContent
    {
        public MemoryStream MemoryStream { get; private set; }
        public string ContentType { get; private set; }
        public string FileName { get; private set; }

        public FileContent(MemoryStream memoryStream, string contentType, string fileName)
        {
            MemoryStream = memoryStream;
            ContentType = contentType;
            FileName = fileName;
        }
    }
}