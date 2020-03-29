using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using Task3.DAL;
using Task3.Models;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        Student student = new Student();
            
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_dbService.GetStudents());
        }
        // [HttpGet]
        // public string GetStudents(string orderBy)
        // {
        //     return $"Debecka, Sikora, Witkowki sortowanie={orderBy}";
        // }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            student.IdStudent = id;
            return Ok("Update complete");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            student = student.IdStudent == id ? null : student;
            return Ok("Student Deleted!");
        }
        
    }
}