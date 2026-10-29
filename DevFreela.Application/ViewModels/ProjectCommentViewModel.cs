namespace DevFreela.Application.ViewModels
{
    public class ProjectCommentViewModel
    {
        public ProjectCommentViewModel(int id, string content, int idUser, string userFullName, DateTime createdAt)
        {
            Id = id;
            Content = content;
            IdUser = idUser;
            UserFullName = userFullName;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string Content { get; private set; }
        public int IdUser { get; private set; }
        public string UserFullName { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
