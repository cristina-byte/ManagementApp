using MediatR;

namespace Application.Commands.UserCommand
{
    public class CreateUserCommand:IRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cnp { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
