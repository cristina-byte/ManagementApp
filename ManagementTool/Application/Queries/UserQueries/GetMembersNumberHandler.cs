using Application.Abstraction;
using MediatR;

namespace Application.Queries.UserQueries
{
    public class GetMembersNumberHandler : IRequestHandler<GetMembersNumberQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMembersNumberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetMembersNumberQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MemberRepository.GetNumberAsync();
        }
    }
}
