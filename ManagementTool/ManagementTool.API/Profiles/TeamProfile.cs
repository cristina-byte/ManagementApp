using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto;

namespace ManagementTool.API.Profiles
{
    public class TeamProfile:Profile
    {
        public TeamProfile()
        {
            Console.WriteLine("Hello from Profile constructor");
            CreateMap<Team, TeamDto>()
            .ForMember(tdto => tdto.Id, opt => opt.MapFrom(team => team.Id))
            .ForMember(tdto => tdto.Name, opt => opt.MapFrom(team => team.Name))
            .ForMember(tdto => tdto.CreatedAt, opt => opt.MapFrom(team => team.CreatedAt));
        }

    }
}
