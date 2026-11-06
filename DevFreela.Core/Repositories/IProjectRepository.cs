using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(string? query, CancellationToken cancellationToken);
        Task<Project?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Project?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Project project, CancellationToken cancellationToken);
        Task UpdateAsync(CancellationToken cancellationToken);
        Task AddCommentAsync(ProjectComment projectComment, CancellationToken cancellationToken);
    }
}
