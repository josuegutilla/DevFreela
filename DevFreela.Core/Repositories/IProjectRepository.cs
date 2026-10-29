using DevFreela.Core.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll(CancellationToken cancellationToken);
        Task<Project?> GetById(int id, CancellationToken cancellationToken);
    }
}
