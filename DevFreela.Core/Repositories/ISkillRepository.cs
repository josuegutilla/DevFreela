using DevFreela.Core.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAll(CancellationToken cancellationToken);
        Task<Skill?> GetById(int id, CancellationToken cancellationToken);
    }
}
