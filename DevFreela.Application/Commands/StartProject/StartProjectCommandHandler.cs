using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;

        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<bool> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id, cancellationToken);

            if (project == null) return false;

            project.Start();
            await _projectRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
