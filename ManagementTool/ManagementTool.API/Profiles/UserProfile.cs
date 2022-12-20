using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;

namespace ManagementTool.API.Profiles
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {
            CreateMap<User, ViewUserDto>();
            CreateMap<User, UserDto>();
        }
    }
}
