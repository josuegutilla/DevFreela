using FluentValidation;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Título é obrigatório.")
                .MinimumLength(6).WithMessage("O título precisa ter mais de 5 caracteres.")
                .MaximumLength(100).WithMessage("O título pode ter no máximo 100 caracteres.");

            RuleFor(p => p.Description)
                .MaximumLength(2000).WithMessage("A descrição pode ter no máximo 2000 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0).WithMessage("O custo total deve ser maior que zero.");
        }
    }
}
