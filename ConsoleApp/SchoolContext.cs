using System.Data.Entity;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public SchoolContext() : base("name=SmallEfTest")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolContext>());

            // Define StudentId as the primary key of StudentAddress
            modelBuilder.Entity<StudentAddress>()
                .HasKey(e => e.StudentId);

            // Define StudentAddress as being optional for Student
            // Define Student as being required for StudentAddress
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.StudentAddress)
                .WithRequired(ad => ad.Student);
        }
    }
}
