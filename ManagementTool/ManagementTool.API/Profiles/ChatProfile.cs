using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;

namespace ManagementTool.API.Profiles
{
    public class ChatProfile:Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, GetChatDto>();
            CreateMap<Message, MessageDto>();
            CreateMap<Chat, ChatDto>();
        }
    }
}
