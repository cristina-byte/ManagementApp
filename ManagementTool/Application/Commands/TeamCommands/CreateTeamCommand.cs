using MediatR;
using Domain.TeamEntities;

namespace Application.Commands.TeamCommands
{
    public class CreateTeamCommand : IRequest<Team>
    {
        public string Name { get; set; }
        public int AdminId { get; set; }

    }
}
