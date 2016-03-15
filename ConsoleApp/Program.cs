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

                Student s = new Student
                {
                    StudentName = "Homer Simpson",
                    StandardId = standard.StandardId
                };

                ctx.Students.Add(s);
                ctx.SaveChanges();
            }
            Console.WriteLine("Student added.");
            Util.WaitForEscape();
        }
    }
}
