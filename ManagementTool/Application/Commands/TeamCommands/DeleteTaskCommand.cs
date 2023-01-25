using MediatR;

namespace Application.Commands.TeamCommands
{
    public class DeleteTaskCommand:IRequest
    {
        public int TaskId { get; set; }
    }
}
