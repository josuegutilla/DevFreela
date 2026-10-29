using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
