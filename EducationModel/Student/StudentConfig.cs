
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(i => i.Student_ID);
            builder.Property(i => i.Student_ID).ValueGeneratedOnAdd();
            builder.Property(i => i.Student_Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.SchoolName).IsRequired();
      
        }
    }
}
