using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class DeleteOportunityCommand:IRequest
    {
        public int Id { get; set; }
    }
}
