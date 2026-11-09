using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Domain.Services;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _userRepository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            if (await _userRepository.EmailExistsAsync(email, cancellationToken))
                throw new ValidationException([new ValidationFailure("Email", "E-mail já cadastrado.")]);

            var hash = _authService.HashPassword(request.Password);

            var user = new User(
                request.FullName,
                email,
                DateTime.SpecifyKind(request.BirthDate, DateTimeKind.Utc),
                hash,
                request.Role
            );

            await _userRepository.AddAsync(user, cancellationToken);

            return user.Id;
        }
    }
}
