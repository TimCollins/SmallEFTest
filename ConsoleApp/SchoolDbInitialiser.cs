using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class SchoolDbInitialiser : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            AddStandards(context);
            AddCourses(context);
            AddStudents(context);
            AddAddresses(context);

            base.Seed(context);
        }

        private void AddAddresses(SchoolContext context)
        {
            var student = context.Students.FirstOrDefault(s => s.StudentName == "Marge Simpson");
            StudentAddress address = new StudentAddress
            {
                Address1 = "Apt 4A",
                Address2 = "123, Fake Street",
                City = "Springfield",
                Country = "USA",
                State = "NY",
                Student = student
            };

            context.StudentAddresses.Add(address);
            context.SaveChanges();
        }

        private void AddStudents(SchoolContext context)
        {
            var standard = context.Standards.FirstOrDefault(s => s.StandardName == "Gold Standard");

            Student student = new Student
            {
                StudentName = "Marge Simpson",
                StandardId = standard.StandardId
            };

            context.Students.Add(student);
            context.SaveChanges();
        }

        private void AddCourses(SchoolContext context)
        {
            var defaultCourses = new List<Course>
            {
                new Course
                {
                    Name = "Underwater Basket Weaving"
                },
                new Course
                {
                    Name = "Photography"
                }
            };

            context.Courses.AddRange(defaultCourses.ToArray());
            context.SaveChanges();
        }

        private void AddStandards(SchoolContext context)
        {
            var defaultStandards = new List<Standard>
            {
                new Standard
                {
                    StandardName = "Bronze Standard"
                },
                new Standard
                {
                    StandardName = "Silver Standard"
                },
                new Standard
                {
                    StandardName = "Gold Standard"
                }
            };

            context.Standards.AddRange(defaultStandards.ToArray());
            context.SaveChanges();
        }
    }
}
