using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto.EventDtos;

namespace ManagementTool.API.Profiles
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<Event, GetEventDto>();
           
        }

    }
}
