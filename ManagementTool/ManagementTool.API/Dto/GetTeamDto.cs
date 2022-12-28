using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Dto
{
    public class GetTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<UserDto> MemberTeams { get; set; }
        public UserDto Admin { get; set; }
    }
}
