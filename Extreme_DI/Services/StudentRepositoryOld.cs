using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extreme_DI.Models;

namespace Extreme_DI.Services
{
    public class StudentRepositoryOld : IStudentRepository
    {
        private List<StudentModel> students = new List<StudentModel>
        {
            new StudentModel{StudentID = 1, Name = "Evgeny", Surname = "Petrosyan", Course = 4, Group = "FIIT"}
        };

        public List<StudentModel> GetStudents()
        {
            return students;
        }

        public StudentModel GetStudentModel(int studentID)
        {
            return students.FirstOrDefault(x =>
                x.StudentID == studentID);
        }

        public void UpdateStudent(StudentModel student)
        {
            students[students.FindIndex(x => x.StudentID == student.StudentID)] = student;
        }

        public void AddStudent(StudentModel student)
        {
            students.Add(student);
        }

        public bool DeleteStudent(int studentID)
        {
            var student_index = students.FindIndex(x => x.StudentID == studentID);
            if (student_index != -1)
            {
                students.RemoveAt(student_index);
                return true;
            }

            return false;
        }
    }
}
