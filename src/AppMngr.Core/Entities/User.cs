namespace AppMngr.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PwdHash { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
