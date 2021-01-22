using AutoMapper;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
        }
    }
}