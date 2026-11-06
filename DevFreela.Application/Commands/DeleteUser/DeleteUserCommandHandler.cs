using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null) return false;

            user.Cancel();
            await _userRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
