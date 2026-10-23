using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title, string description, decimal totalCost, ProjectStatusEnum status)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Status = status;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
    }
}
