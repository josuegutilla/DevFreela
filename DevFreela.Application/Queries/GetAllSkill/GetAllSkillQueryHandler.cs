using DevFreela.Application.ViewModels;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkill
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillQueryHandler(ISkillRepository repository)
        {
            _skillRepository = repository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAll(cancellationToken);
            var SkillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();

            return SkillsViewModel;
        }
    }
}
