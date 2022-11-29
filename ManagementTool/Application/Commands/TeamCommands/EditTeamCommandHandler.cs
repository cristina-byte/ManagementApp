using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    internal class EditTeamCommandHandler : IRequestHandler<EditTeamCommand>
    {
        private ITeamRepository _teamRepository;

        public EditTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Task<Unit> Handle(EditTeamCommand command, CancellationToken cancellationToken)
        {
            _teamRepository.UpdateName(command.Id, command.Name);
            return Unit.Task;
        }
    }
}
