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
                Student s = new Student
                {
                    StudentName = "Homer Simpson"
                };

                ctx.Students.Add(s);
                ctx.SaveChanges();
            }
            Console.WriteLine("Student added.");
            Util.WaitForEscape();
        }
    }
}
