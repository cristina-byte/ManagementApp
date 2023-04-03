using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto;
using ManagementTool.API.Dto.TeamDtos;

namespace ManagementTool.API.Profiles
{
    public class TeamProfile:Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, GetTeamDto>();
            CreateMap<Team, TeamDto>()
            .ForMember(tdto => tdto.Id, opt => opt.MapFrom(team => team.Id))
            .ForMember(tdto => tdto.Name, opt => opt.MapFrom(team => team.Name))
            
            .ForMember(tdto => tdto.CreatedAt, opt => opt.MapFrom(team => team.CreatedAt));
        }
    }
}
