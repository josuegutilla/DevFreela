using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);

            if (project == null) return false;

            project.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
