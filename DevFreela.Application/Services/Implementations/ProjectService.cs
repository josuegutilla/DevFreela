using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(int id, CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projetos = _dbContext.Projects
                .Select(p => new ProjectViewModel(p.Title, p.Description, p.TotalCost, p.Status))
                .ToList();

            return projetos;
        }

        public ProjectDetailsViewModel? GetById(int id)
        {
            var projeto = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (projeto == null) return null;

            var projetoDetailsViewModel = new ProjectDetailsViewModel(projeto.Title, projeto.Description, projeto.TotalCost, projeto.Status, projeto.StartedAt, projeto.FinishedAt, projeto.Client.FullName, projeto.Client.Email, projeto.Freelancer.FullName, projeto.Freelancer.Email);

            return projetoDetailsViewModel;
        }

        public void Update(int id, UpdateProjectInputModel inputModel)
        {
            var projeto = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            projeto.Update(projeto.Title, projeto.Description, projeto.TotalCost);

            _dbContext.SaveChanges();
        }

        public void Start(int id)
        {
            var projeto = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            projeto.Start();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var projeto = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            projeto.Finish();

            _dbContext.SaveChanges();
        }
    }
}
