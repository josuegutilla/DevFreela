using FluentValidation;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(u => u.FullName)
                .NotEmpty().WithMessage("Nome completo é obrigatório.")
                .MaximumLength(150).WithMessage("Nome completo pode ter no máximo 150 caracteres.");

            RuleFor(u => u.BirthDate)
                .NotEmpty().WithMessage("Data de nascimento é obrigatória")
                .LessThan(DateTime.UtcNow).WithMessage("A data de nascimento deve estar no passado.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(8).WithMessage("A senha precisa ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha precisa de uma letra maiúscula.")
                .Matches("[0-9]").WithMessage("A senha precisa de um número.");

            RuleFor(u => u.Role)
                .Must(r => r is "client" or "freelancer").WithMessage("Role deve ser 'client' ou 'freelancer'.");
        }
    }
}
