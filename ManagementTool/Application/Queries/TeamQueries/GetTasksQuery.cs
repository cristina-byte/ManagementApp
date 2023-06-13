using Domain.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTasksQuery:IRequest<IEnumerable<ToDo>>
    {
        public int TeamId { get; set; }
    }
}
