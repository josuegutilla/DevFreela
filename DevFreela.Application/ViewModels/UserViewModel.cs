using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string fullName, string email, bool active)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Active = active;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
    }
}
