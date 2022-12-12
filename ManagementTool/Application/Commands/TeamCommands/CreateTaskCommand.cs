using MediatR;

namespace Application.Commands.TeamCommands
{
    public class CreateTaskCommand:IRequest
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public int ToDoId { get; set; }
    }
}
