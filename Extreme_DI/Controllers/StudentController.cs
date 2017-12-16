using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Extreme_DI.Models;
using Extreme_DI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Extreme_DI.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext context { get; set; }

        public StudentController(StudentContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            return View(context.GetStudents());
        }

        [HttpGet]
        public IActionResult Profile(int studentID)
        {
            var student = context.GetStudentModel(studentID);
            if (student != null)
                return View(student);

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(int studentID)
        {
            return View(context.GetStudentModel(studentID));
        }

        [HttpPost]
        public IActionResult Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                context.UpdateStudent(student);
                return RedirectToAction("Profile", new { studentID = student.StudentID });
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody]StudentModel student)
        {
            if (ModelState.IsValid)
            {
                context.AddStudent(student);
                return RedirectToAction("All");
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int studentID)
        {
            if (context.DeleteStudent(studentID))
            { 
                return RedirectToAction("All");
            }

            return BadRequest();
        }
    }
}
