using System;
using System.Data.Entity;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = GetStudent(1);
            //const string output = "Name: {0}\nAddress: {1}\nStandard: {2}";
            //Console.WriteLine(output, student.StudentName, student.StudentAddress.City, student.Standard.StandardName);

            Util.WaitForEscape();
        }

        private static Student GetStudent(int id)
        {
            var student = new Student();
            using (var context = new SchoolContext())
            {
                student = context.Students
                    .Include(s => s.Standard)
                    .Include(s => s.StudentAddress)
                    .FirstOrDefault(s => s.StudentID == id);
            }

            return student;
        }
    }
}
