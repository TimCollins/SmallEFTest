﻿using System;
using System.Data.Entity;
using System.Linq;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var ctx = new SchoolContext())
            //{
            //    AddEntities(ctx);
            //}

            var student = GetStudent(2);
            const string output = "Name: {0}\nAddress: {1}\nStandard: {2}";
            
            Console.WriteLine(output, student.StudentName, student.StudentAddress.City, student.Standard.StandardName);
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

        private static void AddEntities(SchoolContext ctx)
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
    }
}
