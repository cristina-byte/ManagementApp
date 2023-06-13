using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class AddOportunityPositionCommand:IRequest
    {
        public int OportunityId { get; set; }
        public string Name { get; set; }
        public int LeftSits { get; set; }

    }
}
