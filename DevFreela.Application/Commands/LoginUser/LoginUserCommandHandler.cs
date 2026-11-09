using DevFreela.Application.ViewModels;
using DevFreela.Domain.Repositories;
using DevFreela.Domain.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();
            var user = await _userRepository.GetByEmailIncludingInactiveAsync(email, cancellationToken);

            // a mesma resposta para e-mail inexistente e senha errada
            if (user is null || !_authService.VerifyPassword(request.Password, user.Password))
                return null;

            return new LoginUserViewModel(user.Email, _authService.GenerateJwtToken(user));
        }
    }
}
