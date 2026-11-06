using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpdateSkill
{
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, bool>
    {
        private readonly ISkillRepository _skillRepository;

        public UpdateSkillCommandHandler(ISkillRepository repository)
        {
            _skillRepository = repository;
        }

        public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetByIdAsync(request.Id, cancellationToken);

            if (skill == null) return false;

            skill.Update(request.Description);
            await _skillRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
