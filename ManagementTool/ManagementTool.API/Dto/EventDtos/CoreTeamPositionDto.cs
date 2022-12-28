using Domain.Entities;

namespace ManagementTool.API.Dto.EventDtos
{
    public class CoreTeamPositionDto
    {
        public string Name { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
