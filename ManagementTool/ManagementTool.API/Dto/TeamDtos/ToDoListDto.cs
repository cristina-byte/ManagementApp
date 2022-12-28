
namespace ManagementTool.API.Dto.TeamDtos
{
    public class ToDoListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}
