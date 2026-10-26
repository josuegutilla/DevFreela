using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(
            string title,
            string description,
            decimal totalCost,
            ProjectStatusEnum status,
            DateTime? startedAt,
            DateTime? finishedAt,
            string clientFullName,
            string clientEmail,
            string freelancerFullName,
            string freelancerEmail
            )
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Status = status;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            ClientEmail = clientEmail;
            FreelancerFullname = freelancerFullName;
            FreelancerEmail = freelancerEmail;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string ClientEmail { get; private set; }
        public string FreelancerFullname { get; private set; }
        public string FreelancerEmail { get; private set; }
    }
}
