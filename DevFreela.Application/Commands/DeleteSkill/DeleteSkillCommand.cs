using MediatR;

namespace DevFreela.Application.Commands.DeleteSkill
{
    public class DeleteSkillCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
