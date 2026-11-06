using FluentValidation;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome completo é obrigatório");

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de nascimento é obrigatória");
        }
    }
}
