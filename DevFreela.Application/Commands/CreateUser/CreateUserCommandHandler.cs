using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.FullName,
                request.Email,
                DateTime.SpecifyKind(request.BirthDate, DateTimeKind.Utc),
                request.Password,
                request.Role
            );

            await _userRepository.AddAsync(user, cancellationToken);

            return user.Id;
        }
    }
}
