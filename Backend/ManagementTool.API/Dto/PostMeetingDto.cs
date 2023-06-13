using ManagementTool.API.Dto.UserDtos;
using System.ComponentModel.DataAnnotations;

namespace ManagementTool.API.Dto
{
    public class PostMeetingDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int OrganizatorId { get; set; }
        public IEnumerable<int> GuestsId { get; set; }
    }
}
