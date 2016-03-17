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

            // Define the StdId property of Student as being a foreign key
            // to Standard and that there is a 1-M relationship between the tables
            modelBuilder.Entity<Student>()
                .HasRequired<Standard>(s => s.Standard)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.StdId);
        }
    }
}
