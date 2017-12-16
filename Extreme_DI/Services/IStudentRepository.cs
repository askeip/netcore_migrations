using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extreme_DI.Models;

namespace Extreme_DI.Services
{
    public interface IStudentRepository
    {
        List<StudentModel> GetStudents();
        StudentModel GetStudentModel(int studentID);
        void UpdateStudent(StudentModel student);
        void AddStudent(StudentModel student);
        bool DeleteStudent(int studentID);
    }
}
