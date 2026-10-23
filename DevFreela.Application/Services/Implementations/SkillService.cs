using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillService(DevFreelaDbContext context)
        {
            _dbContext = context;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;

            return skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
        }
    }
}
