using DevFreela.Domain.Entities;
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

        public async Task<List<Project>> GetAllAsync(string? query, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(query))
                projects = projects.Where(p => p.Title.Contains(query) || p.Description.Contains(query));

            return await projects.ToListAsync(cancellationToken);
        }

        public async Task<Project?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Projects
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Project?> GetDetailsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Projects
                .AsNoTracking()
                .Include(p => p.Comments)
                .ThenInclude(pc => pc.User)
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task AddAsync(Project project, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddCommentAsync(ProjectComment projectComment, CancellationToken cancellationToken)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Projects.AnyAsync(p => p.Id == id, cancellationToken);
        }
    }
}
