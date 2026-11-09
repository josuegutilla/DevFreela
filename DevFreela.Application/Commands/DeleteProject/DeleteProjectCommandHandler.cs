using DevFreela.Domain.Enums;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ProjectCommandResult>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<ProjectCommandResult> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);

            if (project == null) return ProjectCommandResult.NotFound;

            if (project.IdClient != request.IdUser) return ProjectCommandResult.Forbidden;

            project.Cancel();
            await _projectRepository.UpdateAsync(cancellationToken);

            return ProjectCommandResult.Success;
        }
    }
}
