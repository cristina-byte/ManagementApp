using MediatR;

namespace Application.Commands.TeamCommands
{
    public class CreateToDoListCommand:IRequest
    {
        public int TeamId { get;  set; }
        public string Name { get;  set; }
    }
}
