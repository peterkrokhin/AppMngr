namespace AppMngr.Core
{
    public class NumField
    {
        public int Id { get; set; }
        public double Value { get; set; }
        
        public int AppTypeId { get; set; }
        public AppType Type { get; set; }
        
    }
}
