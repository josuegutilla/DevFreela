using DevFreela.Core.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken);
        Task<Skill?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Skill skill, CancellationToken cancellationToken);
        Task UpdateAsync(CancellationToken cancellationToken);
    }
}
