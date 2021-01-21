using System;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
