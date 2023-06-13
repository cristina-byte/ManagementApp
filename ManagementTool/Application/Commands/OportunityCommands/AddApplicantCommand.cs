using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class AddApplicantCommand:IRequest
    {
        public int OportunityId { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
    }
}
