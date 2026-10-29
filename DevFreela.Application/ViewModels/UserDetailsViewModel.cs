namespace DevFreela.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string fullName, string email, DateTime birthDate, bool active, List<SkillViewModel> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
            Skills = skills;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public List<SkillViewModel> Skills { get; private set; }
    }
}
