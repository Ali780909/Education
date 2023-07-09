using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class  Context :  IdentityDbContext<User>
    {
        public  Context(DbContextOptions options) : base(options)
        { }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Trainer> trainers { get; set; }
        public DbSet<Project> projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StudentConfig().Configure(modelBuilder.Entity<Student>());
            new TeacherConfig().Configure(modelBuilder.Entity<Teacher>());
            new TrianerConfig().Configure(modelBuilder.Entity<Trainer>());
            new ProjectConfig().Configure(modelBuilder.Entity<Project>());
            modelBuilder.MapRelations();
            base.OnModelCreating(modelBuilder);
        }
      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }*/

    }
}
