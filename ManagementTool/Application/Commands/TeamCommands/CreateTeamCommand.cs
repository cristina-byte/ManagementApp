using Domain.Entities;
using MediatR;
namespace Application.Commands.TeamCommands
{
    public class CreateTeamCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Admin { get; set; }

    }
}
