using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;

namespace ManagementTool.API.Profiles
{
    public class ChatProfile:Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, ChatDto>();
            CreateMap<Message, MessageDto>();
        }
    }
}
