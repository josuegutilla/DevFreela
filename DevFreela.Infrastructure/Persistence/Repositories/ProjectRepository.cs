using DevFreela.Core.Entities;
using DevFreela.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext context)
        {
            _dbContext = context;   
        }

        public async Task<List<Project>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Projects
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Project?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Projects
                .AsNoTracking()
                .Include(p => p.Comments)
                .ThenInclude(pc => pc.User)
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}
