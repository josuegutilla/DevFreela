using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel? GetById(int id);
        int Create(NewProjectInputModel inputModel);
        bool Update(int id, UpdateProjectInputModel inputModel);
        bool CreateComment(int id, CreateCommentInputModel inputModel);
        bool Delete(int id);
        bool Start(int id);
        bool Finish(int id);
    }
}
