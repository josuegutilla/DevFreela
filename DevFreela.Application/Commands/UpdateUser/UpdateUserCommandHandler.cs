using DevFreela.Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DevFreela.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetActiveByIdAsync(request.Id, cancellationToken);

            if (user == null) return false;

            var email = request.Email.Trim().ToLowerInvariant();

            if (!string.Equals(user.Email, email) && await _userRepository.EmailExistsAsync(email, cancellationToken))
                throw new ValidationException([new ValidationFailure("Email", "E-mail já cadastrado.")]);

            user.Update(request.FullName, email);
            await _userRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
