using System.Data.Entity.ModelConfiguration;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            ToTable("Student");

            Property(p => p.DateOfBirth)
                .HasColumnName("DoB")
                .HasColumnOrder(3)
                .HasColumnType("datetime2");

            Property(p => p.StudentName)
                .HasMaxLength(50);
        }
    }
}
