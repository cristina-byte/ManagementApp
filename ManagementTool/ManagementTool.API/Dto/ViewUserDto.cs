using Domain.Entities;

namespace ManagementTool.API.Dto
{
    public class ViewUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnp { get; set; }
        public string Email { get; set; }
        public string Phone { get; set;}
        public ICollection<CoreTeamPositionDto> CoreTeamPositions { get; set; }

    }
}
