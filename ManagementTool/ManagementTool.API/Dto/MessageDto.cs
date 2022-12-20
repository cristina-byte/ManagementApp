using Domain.Entities;

namespace ManagementTool.API.Dto
{
    public class MessageDto
    {
        public int Id { get; private set; }
        public DateTime SentAt { get; set; }
        public string Content { get; set; }
        public UserDto Sender { get; set; }
    }
}
