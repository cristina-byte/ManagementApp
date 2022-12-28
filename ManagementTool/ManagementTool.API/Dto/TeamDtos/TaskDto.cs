using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto.UserDtos;

namespace ManagementTool.API.Dto.TeamDtos
{
    public class TaskDto
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public ICollection<UserDto> AssignedTo { get; set; }
        public string Status { get; set; }
    }
}
