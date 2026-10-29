using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdSkill
{
    public class GetByIdSkillQuery : IRequest<SkillViewModel?>
    {
        public int Id { get; set; }
    }
}
