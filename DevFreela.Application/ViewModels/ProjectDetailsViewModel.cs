using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(string title, string description, decimal totalCost, ProjectStatusEnum status, DateTime? startedAt, DateTime? finishedAt)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Status = status;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
    }
}
