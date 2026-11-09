using DevFreela.Domain.Enums;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ProjectCommandResult>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<ProjectCommandResult> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);

            if (project == null) return ProjectCommandResult.NotFound;

            if (project.IdClient != request.IdUser) return ProjectCommandResult.Forbidden;

            project.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.UpdateAsync(cancellationToken);

            return ProjectCommandResult.Success;
        }
    }
}
