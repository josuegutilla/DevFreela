using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.DeleteSkill
{
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, bool>
    {
        private readonly ISkillRepository _skillRepository;

        public DeleteSkillCommandHandler(ISkillRepository repository)
        {
            _skillRepository = repository;
        }

        public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetByIdAsync(request.Id, cancellationToken);

            if (skill == null) return false;

            skill.Deactivate();
            await _skillRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
