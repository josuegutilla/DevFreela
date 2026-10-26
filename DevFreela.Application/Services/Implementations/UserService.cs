using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user.Id;
        }

        public void Update(int id, UserUpdateInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            user.Update(inputModel.FullName, inputModel.Email);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            user.Cancel();

            _dbContext.SaveChanges();
        }

        public List<UserViewModel> GetAll(string? query)
        {
            var users = _dbContext.Users;

            return users.Select(u => new UserViewModel(u.Id, u.FullName, u.Email, u.Active)).ToList();
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            var userDetailsViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, user.Active, user.Skills);

            return userDetailsViewModel;
        }
    }
}
