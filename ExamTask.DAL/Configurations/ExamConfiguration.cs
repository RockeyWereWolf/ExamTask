using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExamTask.Core.Entities;
using Microsoft.Data.SqlClient;

namespace ExamTask.DAL.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(e => e.Grade)
                .IsRequired()
                .HasPrecision(1);
            builder.HasOne(e => e.Lesson)
                .WithMany(l => l.Exams)
                .HasForeignKey(e => e.LessonId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Student)
                .WithMany(s => s.Exams)
                .HasForeignKey(e => e.StudentId);
        }
    }
}
