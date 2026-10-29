using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateSkillCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _dbContext.Skills.AddAsync(skill, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return skill.Id;
        }
    }
}
