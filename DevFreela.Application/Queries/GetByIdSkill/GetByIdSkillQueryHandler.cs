using DevFreela.Application.ViewModels;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdSkill
{
    public class GetByIdSkillQueryHandler : IRequestHandler<GetByIdSkillQuery, SkillViewModel?>
    {
        private readonly ISkillRepository _skillRepository;

        public GetByIdSkillQueryHandler(ISkillRepository repository)
        {
            _skillRepository = repository;
        }

        public async Task<SkillViewModel?> Handle(GetByIdSkillQuery request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetById(request.Id, cancellationToken);

            if (skill == null ) return null;

            var skillViewModel = new SkillViewModel(skill.Id, skill.Description);

            return skillViewModel;
        }
    }
}
