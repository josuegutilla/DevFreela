using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateSkill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, bool>
    {
        private readonly DevFreelaDbContext _dbContext;

        public UpdateSkillCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _dbContext.Skills.SingleOrDefaultAsync(s => s.Id == request.Id && s.Active, cancellationToken);

            if (skill == null) return false;

            skill.Update(request.Description);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
