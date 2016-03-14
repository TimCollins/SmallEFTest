using System.Data.Entity;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}
