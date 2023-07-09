using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");
            builder.HasKey(i => i.Teacher_ID);
            builder.Property(i => i.Teacher_ID).ValueGeneratedOnAdd();
            builder.Property(i => i.Teacher_Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Address).IsRequired();
            builder.Property(i => i.ProjectID).IsRequired();
        }
    }
}
