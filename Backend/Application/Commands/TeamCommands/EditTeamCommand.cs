using MediatR;

namespace Application.Commands.TeamCommands
{
    public class EditTeamCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
