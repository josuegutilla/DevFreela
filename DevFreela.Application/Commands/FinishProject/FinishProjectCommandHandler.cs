using DevFreela.Domain.Enums;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, ProjectCommandResult>
    {
        private readonly IProjectRepository _projectRepository;

        public FinishProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<ProjectCommandResult> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);

            if (project == null) return ProjectCommandResult.NotFound;

            if (request.IdUser != project?.IdClient) return ProjectCommandResult.Forbidden;

            project.Finish();
            await _projectRepository.UpdateAsync(cancellationToken);

            return ProjectCommandResult.Success;
        }
    }
}
