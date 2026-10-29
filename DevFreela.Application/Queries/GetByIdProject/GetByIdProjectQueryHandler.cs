using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel?>
    {
        private readonly IProjectRepository _projectRepository;

        public GetByIdProjectQueryHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        public async Task<ProjectDetailsViewModel?> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id, cancellationToken);

            if (project == null) return null;

            var comments = project.Comments
                .OrderBy(c => c.CreatedAt)
                .Select(c => new ProjectCommentViewModel(c.Id, c.Content, c.IdUser, c.User.FullName, c.CreatedAt))
                .ToList();

            var projetoDetailsViewModel = new ProjectDetailsViewModel(
                project.Title,
                project.Description,
                project.TotalCost,
                project.Status,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Client.Email,
                project.Freelancer?.FullName,
                project.Freelancer?.Email,
                comments
            );

            return projetoDetailsViewModel;
        }
    }
}
