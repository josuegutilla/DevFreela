using FluentValidation;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(s => s.Description)
            .NotEmpty().WithMessage("A descrição da skill é obrigatória.")
            .MaximumLength(50).WithMessage("A descrição pode ter no máximo 50 caracteres.");
        }
    }
}
