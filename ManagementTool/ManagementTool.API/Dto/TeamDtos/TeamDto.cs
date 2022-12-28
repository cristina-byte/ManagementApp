using AutoMapper;
using Domain.Entities;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Dto.TeamDtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ChatId { get; set; }

    }
}
