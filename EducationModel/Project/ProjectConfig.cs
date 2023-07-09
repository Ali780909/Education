using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(i => new { i.Project_ID }); /*Trainer_ID*/
            builder.Property(i => i.Project_ID).ValueGeneratedOnAdd();
            builder.Property(i => i.Project_Name).IsRequired();


        }
    }
}
