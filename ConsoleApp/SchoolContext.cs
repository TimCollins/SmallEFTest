using System.Data.Entity;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

        public SchoolContext() : base("name=SmallEfTest")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolContext>());
        }
    }
}
