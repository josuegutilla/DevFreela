using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkill
{
    public class GetAllSkillQuery : IRequest<List<SkillViewModel>>
    {
    }
}
