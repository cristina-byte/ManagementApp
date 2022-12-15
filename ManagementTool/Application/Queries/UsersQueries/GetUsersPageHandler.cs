using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.UsersQueries
{
    public class GetUsersPageHandler : IRequestHandler<GetUsersPageQuery, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersPageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersPageQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MemberRepository.GetMembersPageAsync(request.Page);
        }
    }
}
