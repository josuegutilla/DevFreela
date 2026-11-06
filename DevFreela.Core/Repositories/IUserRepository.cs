using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task UpdateAsync(CancellationToken cancellationToken);
    } 
}
