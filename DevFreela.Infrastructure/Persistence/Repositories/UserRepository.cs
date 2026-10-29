using DevFreela.Core.Entities;
using DevFreela.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Active)
                .ToListAsync(cancellationToken);
        }

        public async Task<User?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
               .AsNoTracking()
               .Where(u => u.Active)
               .Include(u => u.Skills)
               .ThenInclude(us => us.Skill)
               .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
    }
}
