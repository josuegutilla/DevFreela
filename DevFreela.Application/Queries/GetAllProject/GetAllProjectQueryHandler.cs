using DevFreela.Application.ViewModels;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProject
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectQueryHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAll(cancellationToken);

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.Description, p.TotalCost, p.Status))
                .ToList();

            return projectsViewModel;
        }
    }
}
