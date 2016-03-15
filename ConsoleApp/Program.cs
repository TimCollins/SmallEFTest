using System;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                Standard standard = new Standard
                {
                    StandardName = "Top Quality"
                };

                ctx.Standards.Add(standard);
                Console.WriteLine("Standard added.");

                Student s = new Student
                {
                    StudentName = "Homer Simpson",
                    StandardId = standard.StandardId
                };

                ctx.Students.Add(s);
                Console.WriteLine("Student added.");

                StudentAddress address = new StudentAddress
                {
                    Address1 = "Apt 4A",
                    Address2 = "123, Fake Street",
                    City = "Springfield",
                    Country = "USA",
                    State = "NY",
                    Student = s
                };

                ctx.StudentAddresses.Add(address);
                ctx.SaveChanges();
            }

            
            Util.WaitForEscape();
        }
    }
}
