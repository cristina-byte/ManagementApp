using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Dto;

public class GetChatDto
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public ICollection<MessageDto> Messages { get; set; }
    public ICollection<UserDto> Participants { get; set; }
}
