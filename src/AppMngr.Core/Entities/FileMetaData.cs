namespace AppMngr.Core
{
    public class FileMetaData
    {
        public int Id { get; set; }

        public int AppTypeId { get; set; }
        public AppType Type { get; set; }
    }
}