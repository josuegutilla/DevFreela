using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteSkill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, bool>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeleteSkillCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _dbContext.Skills.SingleOrDefaultAsync(s => s.Id == request.Id && s.Active, cancellationToken);

            if (skill == null) return false;

            skill.Deactivate();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
