using System;

namespace ConsoleApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        // This isn't following the naming convention.
        // It should be StandardId.
        public int StdId { get; set; }

        public virtual Standard Standard { get; set; }
        public Teacher Teacher { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }
    }
}
