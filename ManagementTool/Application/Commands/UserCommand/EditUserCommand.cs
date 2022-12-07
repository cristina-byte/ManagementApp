using MediatR;

namespace Application.Commands.UserCommand
{
    public class EditUserCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Cnp { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
