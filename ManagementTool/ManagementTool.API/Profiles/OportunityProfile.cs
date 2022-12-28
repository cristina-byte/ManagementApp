using AutoMapper;
using Domain.Entities.OportunityEntities;
using ManagementTool.API.Dto.OportunityDtos;

namespace ManagementTool.API.Profiles
{
    public class OportunityProfile:Profile
    {
        public OportunityProfile()
        {
            CreateMap<Oportunity, OportunityDto>();
            CreateMap<Position, PositionDto>();
        }

    }
}
