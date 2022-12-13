using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommand
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            //verifica mai intai daca parola actuala este corecta
            //obtine parola actuala
            var password = await _unitOfWork.MemberRepository.GetPasswordAsync(request.Id);
            if(password.Equals(request.Password))
            //daca este corecta o actualizeaza cu parola noua
            await _unitOfWork.MemberRepository.ChangePasswordAsync(request.Id, request.NewPassword);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
