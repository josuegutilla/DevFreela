using DevFreela.Domain.Entities;
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

        public async Task<List<User>> GetAllActiveAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Active)
                .ToListAsync(cancellationToken);
        }

        // para os commands: só usuários ativos, sem AsNoTracking e sem Include
        public async Task<User?> GetActiveByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
               .Where(u => u.Active)
               .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        // qualquer usuário, ativo ou desativado (ex.: reativar conta, histórico)
        public async Task<User?> GetByIdInactiveAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
               .Where(u => u.Active == false)
               .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        // metodo byId para as queries com includes e com asnotracking
        public async Task<User?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
               .AsNoTracking()
               .Where(u => u.Active)
               .Include(u => u.Skills)
                    .ThenInclude(us => us.Skill)
               .Include(u => u.OwnedProjects)
               .Include(u => u.Comments)
               .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetByEmailIncludingInactiveAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
        }
    }
}
