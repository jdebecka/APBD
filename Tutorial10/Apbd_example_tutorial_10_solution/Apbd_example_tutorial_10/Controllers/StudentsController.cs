using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apbd_example_tutorial_10.Entities;
using Apbd_example_tutorial_10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apbd_example_tutorial_10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _studentContext;

        public StudentsController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentContext.Student
                                          .Include(s => s.IdEnrollmentNavigation).ThenInclude(e => e.IdStudyNavigation)
                                          .Select(s => new GetStudentsResponse
                                          {
                                              IndexNumber = s.IndexNumber,
                                              FirstName = s.FirstName,
                                              LastName = s.LastName,
                                              BirthDate = s.BirthDate.ToShortDateString(),
                                              Semester = s.IdEnrollmentNavigation.Semester,
                                              Studies = s.IdEnrollmentNavigation.IdStudyNavigation.Name
                                          })
                                          .ToList();
            return Ok(students);
        }
    }
}