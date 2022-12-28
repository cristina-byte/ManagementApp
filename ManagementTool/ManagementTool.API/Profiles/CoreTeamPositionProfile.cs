using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto.EventDtos;

namespace ManagementTool.API.Profiles
{
    public class CoreTeamPositionProfile:Profile
    {
        public CoreTeamPositionProfile()
        {
            CreateMap<CoreTeamPosition, CoreTeamPositionDto>().
                ForMember(ctpdto => ctpdto.EventName, opt => opt.MapFrom(ctp => ctp.Event.Name))
                .ForMember(ctpdto => ctpdto.StartDate, opt => opt.MapFrom(ctp => ctp.Event.StartDate))
                .ForMember(ctpdto => ctpdto.EndDate, opt => opt.MapFrom(ctp => ctp.Event.EndDate));
        }

    }
}
