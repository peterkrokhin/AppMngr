using Microsoft.Extensions.Configuration;

namespace AppMngr.Web
{
    public class FileStorageConfiguration
    {
        public string Path { get; private set; }
        public long FileSizeLimit { get; private set; }
        public string[] PermittedExtensions { get; private set; }
        public string FileNamePrefix { get; private set; }

        public FileStorageConfiguration(IConfiguration configuration)
        {
            Path = configuration["FileStorage:Path"];
            FileSizeLimit = long.Parse(configuration["FileStorage:FileSizeLimit"]);
            PermittedExtensions = configuration["FileStorage:PermittedExtensions"].Split(" ");
            FileNamePrefix = configuration["FileStorage:FileNamePrefix"];
        }
    }
}