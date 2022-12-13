using Application.Abstraction;
using MediatR;

namespace Application.Commands
{
    public class TestHandler : IRequestHandler<TestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestHandler(IUnitOfWork unitOfWork)
        {
            Console.WriteLine("Hello from constructor");
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello from test handler");

            return Task.FromResult(Unit.Value);
        }
    }
}
