using AutoMapper;
using Domain.Entities;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Profiles
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<User, UserDto>();
            CreateMap<MeetingInvited, UserDto>()
                .ForMember(user => user.Id, opt => opt.MapFrom(meetingInvited => meetingInvited.UserId))
                .ForMember(user=>user.ImageLink,opt=>opt.MapFrom(meetingInvited=>meetingInvited.User.ImageLink))
                .ForMember(user => user.Name, opt => opt.MapFrom(MeetingInvited => MeetingInvited.User.Name));
            CreateMap<ChatMember, UserDto>()
                .ForMember(user => user.Id, opt => opt.MapFrom(chatMember => chatMember.UserId))
                .ForMember(user=>user.ImageLink,opt=>opt.MapFrom(chatMember=>chatMember.User.ImageLink))
                .ForMember(user => user.Name, opt => opt.MapFrom(chatMember => chatMember.User.Name));

            CreateMap<MemberTeam, UserDto>()
                .ForMember(user => user.Id, opt => opt.MapFrom(mt => mt.MemberId))
                 .ForMember(user => user.Name, opt => opt.MapFrom(mt => mt.Member.Name))
                  .ForMember(user => user.ImageLink, opt => opt.MapFrom(mt => mt.Member.ImageLink));
                  

        }
    }
}
