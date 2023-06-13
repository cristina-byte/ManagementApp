using Domain.OportunityEntities;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class EditOportunityCommand:IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string ImageLink { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public ICollection<Position> Positions { get; set; }

    }
}
