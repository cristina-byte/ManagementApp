using MediatR;

namespace Application.Commands.TeamCommands
{
    public class AddMembersCommand:IRequest
    {
        public int TeamId { get; set; }
        public ICollection<int> UsersId { get; set;}
    }
}
