using MediatR;

namespace Application.Commands.OportunityCommands
{
   public class DeletePositionCommand:IRequest
    {
        public int Id { get; set; }
    }
}
