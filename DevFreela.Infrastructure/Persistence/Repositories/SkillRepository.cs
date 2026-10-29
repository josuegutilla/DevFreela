using DevFreela.Core.Entities;
using DevFreela.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Skill>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Skills
                .AsNoTracking()
                .Where(u => u.Active)
                .ToListAsync(cancellationToken);
        }

        public async Task<Skill?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Skills
                .AsNoTracking()
                .Where(s => s.Active)
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
    }
}
