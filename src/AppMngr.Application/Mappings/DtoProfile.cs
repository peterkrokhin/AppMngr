using AutoMapper;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<App, AppDto>();
            CreateMap<AppType, AppTypeDto>();
            CreateMap<DateField, DateFieldDto>();
            CreateMap<FileField, FileFieldDto>();
            CreateMap<NumField, NumFieldDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Status, StatusDto>();
            CreateMap<StringField, StringFieldDto>();
            CreateMap<TimeField, TimeFieldDto>();
            CreateMap<User, UserDto>();
        }
    }
}