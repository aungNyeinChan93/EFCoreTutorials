using Microsoft.EntityFrameworkCore;
using Students.Database.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto_05.ConsoleApp1.Students
{
    internal class StudentsDb
    {
        
        public void GetAllStudents()
        {
            AppDbContext db = new AppDbContext();
            var students = db.Students.AsNoTracking().Where(s=>s.StudentId <= 70).ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"Student Email {student.Email}");
            }
        }
    }
}
