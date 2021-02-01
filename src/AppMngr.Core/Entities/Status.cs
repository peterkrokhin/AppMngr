namespace AppMngr.Core
{
    public class Status
    {
        public int Id { get; set; }
        public string Value { get; set; }
        
        public int AppTypeId { get; set; }
        public AppType Type { get; set; } 
    }
}
