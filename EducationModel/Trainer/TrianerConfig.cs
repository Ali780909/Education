using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationModel
{
    public class TrianerConfig : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainer");
            builder.HasKey(i => i.Trainer_ID);
            builder.Property(i => i.Trainer_ID).ValueGeneratedOnAdd();
            builder.Property(i => i.Trainer_Name).IsRequired().HasMaxLength(100);
             
        }
    }
}
