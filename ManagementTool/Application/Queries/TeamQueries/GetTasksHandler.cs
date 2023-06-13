using Application.Abstraction;
using Domain.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTasksHandler : IRequestHandler<GetTasksQuery, IEnumerable<ToDo>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTasksHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ToDo>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var toDo = await _unitOfWork.TeamRepository.GetTasksAsync(request.TeamId);
            return toDo;
        }
    }
}
