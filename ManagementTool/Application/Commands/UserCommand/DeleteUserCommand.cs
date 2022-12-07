using MediatR;

namespace Application.Commands.UserCommand
{
    public class DeleteUserCommand:IRequest
    {
        public int Id { get; set; }
    }
}
