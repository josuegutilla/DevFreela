using FluentValidation;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Título é obrigatório.")
                 .MinimumLength(6).WithMessage("O título precisa ter mais de 5 caracteres.")
                .MaximumLength(100).WithMessage("O título pode ter no máximo 100 caracteres.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Descrição é obrigatória.")
               .MaximumLength(2000).WithMessage("A descrição pode ter no máximo 2000 caracteres.");

            RuleFor(p => p.IdClient)
            .GreaterThan(0).WithMessage("Informe o cliente.");

            // o freelancer é opcional: só valida se veio preenchido
            RuleFor(p => p.IdFreelancer)
                .GreaterThan(0).When(p => p.IdFreelancer.HasValue).WithMessage("Freelancer inválido.")
                .NotEqual(p => p.IdClient).When(p => p.IdFreelancer.HasValue).WithMessage("O freelancer não pode ser o próprio cliente.");

            RuleFor(c => c.TotalCost)
                .GreaterThan(0).WithMessage("Custo total deve ser maior que zero.");
        }
    }
}
