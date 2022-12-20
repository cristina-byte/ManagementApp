using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;

namespace ManagementTool.API.Profiles
{
    public class MeetingProfile:Profile
    {
        public MeetingProfile()
        {
            CreateMap<Meeting, MeetingDto>();
              
        }
    }
}
