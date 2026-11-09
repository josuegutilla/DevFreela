using DevFreela.Domain.Enums;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, ProjectCommandResult>
    {
        private readonly IProjectRepository _projectRepository;

        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<ProjectCommandResult> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);

            if (project == null) return ProjectCommandResult.NotFound;

            if (request.IdUser != project?.IdClient) return ProjectCommandResult.Forbidden;

            project.Start();
            await _projectRepository.UpdateAsync(cancellationToken);

            return ProjectCommandResult.Success;
        }
    }
}
