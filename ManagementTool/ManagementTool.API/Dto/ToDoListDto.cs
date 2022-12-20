using Task2 = Domain.Entities.TeamEntities.Task;

namespace ManagementTool.API.Dto
{
    public class ToDoListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}
