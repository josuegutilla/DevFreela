namespace DevFreela.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(
            string fullName,
            string email,
            DateTime birthDate,
            bool active, 
            string role,
            List<SkillViewModel> skills,
            List<ProjectViewModel> projects, 
            List<ProjectCommentViewModel> comments)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
            Role = role;
            Skills = skills;
            Projects = projects;
            Comments = comments;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public string Role { get; set; }
        public List<SkillViewModel> Skills { get; private set; }
        public List<ProjectViewModel> Projects { get; private set; }
        public List<ProjectCommentViewModel> Comments { get; private set; }
    }
}
