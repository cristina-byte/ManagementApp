using System.ComponentModel.DataAnnotations;

namespace ManagementTool.API.Dto
{
    public class PutMeetingDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
