using FluentValidation;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty().WithMessage("O comentário não pode ser vazio.")
                .MaximumLength(500).WithMessage("O comentário pode ter no máximo 500 caracteres.");

            RuleFor(c => c.IdUser)
                .GreaterThan(0).WithMessage("Informe o usuário.");
        }
    }
}
