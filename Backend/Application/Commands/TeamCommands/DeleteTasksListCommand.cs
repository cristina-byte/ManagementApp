using MediatR;

namespace Application.Commands.TeamCommands
{
    public class DeleteTasksListCommand:IRequest
    {
        public int TasksListId { get; set; }
    }
}
