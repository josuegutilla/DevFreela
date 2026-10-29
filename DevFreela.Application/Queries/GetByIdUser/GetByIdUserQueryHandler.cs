using DevFreela.Application.ViewModels;
using DevFreela.Domain.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDetailsViewModel?>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdUserQueryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<UserDetailsViewModel?> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id, cancellationToken);

            if (user == null) return null;

            var skills = user.Skills
                .Select(us => new SkillViewModel(us.Id, us.Skill.Description))
                .ToList();

            var userDetailsViewModel = new UserDetailsViewModel(
                user.FullName,
                user.Email,
                user.BirthDate,
                user.Active,
                skills
            );

            return userDetailsViewModel;
        }
    }
}
