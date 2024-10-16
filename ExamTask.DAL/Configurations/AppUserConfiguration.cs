using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTask.Core.Entities;

namespace ExamTask.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(30);
			builder.Property(x => x.Surname)
				.IsRequired()
				.HasMaxLength(30);
			builder.Property(x => x.ClassNumber)
				.HasPrecision(2);
		}
    }
}
