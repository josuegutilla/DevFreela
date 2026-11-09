using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllActiveAsync(CancellationToken cancellationToken);
        Task<User?> GetActiveByIdAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetByIdInactiveAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task UpdateAsync(CancellationToken cancellationToken);
        Task<User?> GetByEmailIncludingInactiveAsync(string email, CancellationToken cancellationToken);
        Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
    } 
}
