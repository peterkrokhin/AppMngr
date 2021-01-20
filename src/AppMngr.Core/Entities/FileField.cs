namespace AppMngr.Core
{
    public class FileField
    {
        public int Id { get; set; }
        public byte[] Value { get; set; }
        
        public int AppTypeId { get; set; }
        public AppType Type { get; set; }
        
    }
}
