using Microsoft.Extensions.Configuration;

namespace AppMngr.Web
{
    public class FileStorageSettings
    {
        public string Path { get; private set; }
        public long FileSizeLimit { get; private set; }
        public string[] PermittedExtensions { get; private set; }
        public string FileNamePrefix { get; private set; }

        public FileStorageSettings(IConfiguration configuration)
        {
            Path = configuration["FileStorageSettings:Path"];
            FileSizeLimit = long.Parse(configuration["FileStorageSettings:FileSizeLimit"]);
            PermittedExtensions = configuration["FileStorageSettings:PermittedExtensions"].Split(" ");
            FileNamePrefix = configuration["FileStorageSettings:FileNamePrefix"];
        }
    }
}