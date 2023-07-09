using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public static class DbRelations
    {
        public static void MapRelations(this ModelBuilder builder)
        {
            builder.Entity<Project>()
               .HasOne(i => i.student)
               .WithMany(i => i.project)
               .HasForeignKey(i => i.Student_Id)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
              .HasOne(i => i.teacher)
              .WithMany(i => i.project)
              .HasForeignKey(i => i.Teacher_Id)
              .OnDelete(DeleteBehavior.Cascade);



            builder.Entity<Project>()
                .HasOne(i => i.trainers)
                .WithMany(p => p.Projects)
                 .HasForeignKey(i => i.Trainer_ID).OnDelete(DeleteBehavior.NoAction);


            builder.Entity<User>()
              .HasOne(i => i.students)
               .WithOne(i => i.Users)
               .HasForeignKey<User>(i => i.Student_ID);


            builder.Entity<User>()
            .HasOne(i => i.teachers)
             .WithOne(i => i.Users)
             .HasForeignKey<User>(i => i.Teacher_ID);

            builder.Entity<User>()
            .HasOne(i => i.trainers)
             .WithOne(i => i.Users)
             .HasForeignKey<User>(i => i.Teacher_ID);







        }
    }
}
