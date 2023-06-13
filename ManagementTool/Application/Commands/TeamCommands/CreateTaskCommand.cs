using MediatR;
using Task =Domain.TeamEntities.Task;

namespace Application.Commands.TeamCommands
{
    public class CreateTaskCommand:IRequest<Task>
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public int ToDoId { get; set; }
    }
}
