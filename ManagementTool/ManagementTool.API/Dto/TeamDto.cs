using AutoMapper;
using Domain.Entities;

namespace ManagementTool.API.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
