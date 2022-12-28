using Domain.Entities;

namespace ManagementTool.API.Dto.EventDtos
{
    public class GetEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CoreTeamPositionDto> CoreTeamPositions { get; set; }
    }
}
