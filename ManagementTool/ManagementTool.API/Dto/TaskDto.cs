using Domain.Entities.TeamEntities;

namespace ManagementTool.API.Dto
{
    public class TaskDto
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public ICollection<UserDto> AssignedTo { get; set; }
        public string Status { get; set; }
    }
}
