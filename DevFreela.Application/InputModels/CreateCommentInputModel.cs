namespace DevFreela.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public CreateCommentInputModel(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public int IdUser { get; private set; }
    }
}
