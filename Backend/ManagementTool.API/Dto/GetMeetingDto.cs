using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Dto
{
    public class GetMeetingDto
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserDto Organizator { get; set; }
        public ICollection<UserDto> MeetingInvited { get; set; }
    }
}
