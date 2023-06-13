using MediatR;

namespace Application.Commands.TeamCommands
{
    public class DeleteTeamCommand:IRequest
    {
        public int Id { get; set; }
    }
}
