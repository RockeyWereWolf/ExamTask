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
	public class LessonConfiguraion : IEntityTypeConfiguration<Lesson>
	{
		public void Configure(EntityTypeBuilder<Lesson> builder)
		{
			builder.Property(b => b.LessonName)
				.IsRequired()
				.HasMaxLength(30);
			builder.Property(b => b.ClassNumber)
				 .IsRequired()
				 .HasPrecision(2);
			builder.HasOne(b => b.Teacher)
				.WithMany(u => u.Lessons)
				.HasForeignKey(b => b.TeacherId);
		}
	}
}
