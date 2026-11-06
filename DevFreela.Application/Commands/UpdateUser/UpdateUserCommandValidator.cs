using FluentValidation;

namespace DevFreela.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.FullName)
                .NotEmpty().WithMessage("Nome completo é obrigatório.")
                .MaximumLength(150).WithMessage("Nome completo pode ter no máximo 150 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido");
        }
    }
}
