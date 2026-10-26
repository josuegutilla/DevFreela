using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll(string? query);
        UserDetailsViewModel GetById(int id);
        int Create(CreateUserInputModel inputModel);
        void Update(int id, UserUpdateInputModel inputModel);
        void Delete(int id);
    }
}
