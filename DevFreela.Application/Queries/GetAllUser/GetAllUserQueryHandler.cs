using DevFreela.Application.ViewModels;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll(cancellationToken);
                
            var usersViewModel = users
                .Select(u => new UserViewModel(u.Id, u.FullName, u.Email, u.Active))
                .ToList();

            return usersViewModel;
        }
    }
}
