using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new("Project 1", "Minha descricao 1", 1, 1, 10000),
                new("Project 2", "Minha descricao 2", 1, 1, 10000),
                new("Project 3", "Minha descricao 3", 1, 1, 10000),
                new("Project 4", "Minha descricao 4", 1, 1, 10000),
            };

            Users = new List<User>
            {
                new("Josué Souza", "gutillaj@gmail.com", new DateTime(2004, 10, 30)),
                new("Leticia oliveira", "lele@gmail.com", new DateTime(2007, 02, 14)),
                new("João Pedro", "joao@gmail.com", new DateTime(2007, 12, 06)),
            };

            Skills = new List<Skill>
            {
                new("C#"),
                new("ASP.NET"),
                new("JavaScript"),
                new("TypeScript"),
                new("SQL"),
            };
        }

        public List<Project> Projects { get; private set; }
        public List<User> Users { get; private set; }
        public List<Skill> Skills { get; private set; }
    }
}
