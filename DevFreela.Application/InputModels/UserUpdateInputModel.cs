namespace DevFreela.Application.InputModels
{
    public class UserUpdateInputModel
    {
        public UserUpdateInputModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
