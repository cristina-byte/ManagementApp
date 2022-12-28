using Domain.Entities.OportunityEntities;

namespace ManagementTool.API.Dto.OportunityDtos
{
    public class OportunityDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public ICollection<PositionDto> Positions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public DateTime ApplicationDeadline { get; set; }
    }
}
