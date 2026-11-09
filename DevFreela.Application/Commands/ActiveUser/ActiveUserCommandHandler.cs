using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.ActiveUser
{
    public class ActiveUserCommandHandler : IRequestHandler<ActiveUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ActiveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdInactiveAsync(request.Id, cancellationToken);

            if (user == null) return false;

            user.Activate();
            await _userRepository.UpdateAsync(cancellationToken);

            return true;
        }
    }
}
