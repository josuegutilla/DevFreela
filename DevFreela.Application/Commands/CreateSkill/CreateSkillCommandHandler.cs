using DevFreela.Core.Entities;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
    {
        private readonly ISkillRepository _skillRepository;

        public CreateSkillCommandHandler(ISkillRepository repository)
        {
            _skillRepository = repository;
        }

        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _skillRepository.AddAsync(skill, cancellationToken);

            return skill.Id;
        }
    }
}
