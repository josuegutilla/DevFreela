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

        public async Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Skills
                .AsNoTracking()
                .Where(u => u.Active)
                .ToListAsync(cancellationToken);
        }

        public async Task<Skill?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Skills
                .Where(s => s.Active)
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task AddAsync(Skill skill, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(skill, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
