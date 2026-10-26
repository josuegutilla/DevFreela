using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {
        }

        // minhas tabelas no banco relacional
        public DbSet<Project> Projects { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Skill> Skills { get; private set; }
        public DbSet<UserSkill> UserSkills { get; private set; }
        public DbSet<ProjectComment> ProjectComments { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .ToTable("projeto")
                .HasKey(p => p.Id);

            // relacionamentos

            // projeto
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(c => c.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);


            // comentario
            modelBuilder.Entity<ProjectComment>()
                .ToTable("comentario_projeto")
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdProject);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(p => p.IdUser);


            // habiliades
            modelBuilder.Entity<Skill>()
               .ToTable("habilidade")
               .HasKey(s => s.Id);

            modelBuilder.Entity<UserSkill>()
                .ToTable("habilidade_usuario")
                .HasKey(s => s.Id);


            // usuario
            modelBuilder.Entity<User>()
                .ToTable("usuario")
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
