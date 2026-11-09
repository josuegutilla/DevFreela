using MediatR;

namespace DevFreela.Application.Commands.ActiveUser
{
    public class ActiveUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
