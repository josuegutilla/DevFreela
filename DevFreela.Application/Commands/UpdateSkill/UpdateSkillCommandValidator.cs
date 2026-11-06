using FluentValidation;

namespace DevFreela.Application.Commands.UpdateSkill
{
    public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
    {
        public UpdateSkillCommandValidator()
        {
            RuleFor(s => s.Description)
            .NotEmpty().WithMessage("A descrição da skill é obrigatória.")
            .MaximumLength(50).WithMessage("A descrição pode ter no máximo 50 caracteres.");
        }
    }
}
