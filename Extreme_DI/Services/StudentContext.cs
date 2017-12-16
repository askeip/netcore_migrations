using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Extreme_DI.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }

        public StudentContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().HasKey(x => x.StudentID);
        }

        public List<StudentModel> GetStudents()
        {
            return Students.ToList();
        }

        public StudentModel GetStudentModel(int studentID)
        {
            return Students.FirstOrDefault(x =>
                x.StudentID == studentID);
        }

        public void UpdateStudent(StudentModel student)
        {
            Students.Update(student);
            SaveChanges();
        }

        public void AddStudent(StudentModel student)
        {
            Students.Add(student);
            SaveChanges();
        }

        public bool DeleteStudent(int studentID)
        {
            var student = Students.FirstOrDefault(x => x.StudentID == studentID);
            if (student != null)
            {
                Students.Remove(student);
                SaveChanges();
                return true;
            }

            return false;
        }
    }
}
