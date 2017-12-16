using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extreme_DI.Models;

namespace Extreme_DI.Services
{
    public class StudentRepository : IStudentRepository
    {
        private StudentContext context;

        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }

        public List<StudentModel> GetStudents()
        {
            return context.Students.ToList();
        }

        public StudentModel GetStudentModel(int studentID)
        {
            return context.Students.FirstOrDefault(x =>
                x.StudentID == studentID);
        }

        public void UpdateStudent(StudentModel student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }

        public void AddStudent(StudentModel student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public bool DeleteStudent(int studentID)
        {
            var student = context.Students.FirstOrDefault(x => x.StudentID == studentID);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
