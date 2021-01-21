using AutoMapper;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}