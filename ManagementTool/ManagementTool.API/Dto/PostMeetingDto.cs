using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Dto
{
    public class PostMeetingDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganizatorId { get; set; }
    }
}
