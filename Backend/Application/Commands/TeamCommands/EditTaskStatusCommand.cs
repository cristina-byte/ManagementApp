using MediatR;

namespace Application.Commands.TeamCommands
{
    public class EditTaskStatusCommand:IRequest
    {
        public int TaskId { get; set; }
        public Boolean IsDone { get; set; }

    }
}
