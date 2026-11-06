using DevFreela.Domain.Repositories;
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
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null) return false;

            user.Update(request.FullName, request.Email);
            await _userRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
