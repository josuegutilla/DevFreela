using DevFreela.Core.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task<User?> GetById(int id, CancellationToken cancellationToken);
    }
}
