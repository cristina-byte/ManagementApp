using MediatR;

namespace Application.Commands.UserCommand
{
    public class EditUserCommand:IRequest
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
     
    }
}
