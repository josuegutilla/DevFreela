using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel? GetById(int id);
        int Create(NewProjectInputModel inputModel);
        void Update(int id, UpdateProjectInputModel inputModel);
        void CreateComment(int id, CreateCommentInputModel inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
    }
}
