using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
