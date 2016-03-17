using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
