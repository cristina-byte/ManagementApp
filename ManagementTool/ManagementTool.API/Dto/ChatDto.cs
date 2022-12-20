namespace ManagementTool.API.Dto
{
    public class ChatDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string LastMessage { get; set; }
        public ICollection<UserDto> Participants { get; set; }
    }
}
